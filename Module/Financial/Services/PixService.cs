using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Requests;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Monetizacao.Modules.Financial.Services;

public sealed class PixService
(
    TimezoneHandler                 _timezoneHandler,
    ValidationHandler               _validationHandler,
    FinancialRelationalContext      _financialRelationalContext
)
{
    public async Task<bool> FindAsync(long uid, PixRequest model, CancellationToken token = default)
    {
        var query  = @"SELECT 1 FROM Pix";
            query += " WHERE AccountId = @userId AND PixTypeId = @pixTypeId AND Content = AES_ENCRYPT(@content, @encryptionKey) AND Active = 1";
            query += " LIMIT 1";

        var parameters = new[]
        {
            new MySqlParameter("@userId",           uid),
            new MySqlParameter("@pixTypeId",        model.type),
            new MySqlParameter("@content",          model.content),
            new MySqlParameter("@encryptionKey",    _financialRelationalContext.AesKey)
        };

        return await 
            _financialRelationalContext
                .Pixes
                    .FromSqlRaw(query, parameters)
                        .AsNoTracking()
                            .AnyAsync(token);
    }

    public async Task<bool> AddAsync(long uid, PixRequest model, CancellationToken token = default)
    {
        var  query = @"INSERT INTO Pix (AccountId, Content, Active, PixTypeId, CreatedAt)";
            query += " VALUES(@userId, AES_ENCRYPT(@content, @encryptionKey), 1, @pixTypeId, @createdAt)";

        var parameters = new[]
        {
            new MySqlParameter("@userId",           uid),
            new MySqlParameter("@pixTypeId",        model.type),
            new MySqlParameter("@content",          model.content),
            new MySqlParameter("@createdAt",        _timezoneHandler.RightNow()),
            new MySqlParameter("@encryptionKey",    _financialRelationalContext.AesKey)
        };

        int results = await _financialRelationalContext
            .Database
                .ExecuteSqlRawAsync(query, parameters, token);

        return (results >= 1);
    }

    public async Task<IList<PixResponse>> ListAsync(long uid, CancellationToken token = default)
    {
        var query = @"SELECT Id, AccountId, Active, PixTypeId, CreatedAt, AES_DECRYPT(Content, @encryptionKey) AS 'Content'";
            query += " FROM Pix WHERE AccountId = @userId AND Active = 1";

        var parameters = new[]
        {
            new MySqlParameter("@userId",           uid),
            new MySqlParameter("@encryptionKey",    _financialRelationalContext.AesKey)
        };

        return await _financialRelationalContext
            .Pixes
                .FromSqlRaw(query, parameters)
                    .AsNoTracking()
                        .Select(p => new PixResponse(p.Id, p.Content.ToString(), p.PixTypeId, p.CreatedAt))
                            .ToListAsync(token);
    }

    public bool IsModelValid(long? uid)
    {
        if (!_validationHandler.IsIdValid(uid))
            return false;
        
        return true;
    }

    public bool IsModelValid(long? uid, PixRequest model)
    {
        if (!IsModelValid(uid) && model.content.Length > 36)
            return false;

        bool output = false;

        switch(model.type)
        {
            case PixTypeEnum.Email:
                output = _validationHandler.IsEmailValid(model.content);
                break;

            case PixTypeEnum.Cpf:
                output = _validationHandler.IsCpfValid(model.content);
                break;

            case PixTypeEnum.Cnpj:
                output = _validationHandler.IsCnpjValid(model.content);
                break;

            case PixTypeEnum.Phone:
                output = _validationHandler.IsPhoneValid(model.content);
                break;

            case PixTypeEnum.Random:
                output = _validationHandler.IsPixRandomKeyValid(model.content);
                break;
        }

        return output;
    }

    public async Task<bool> PersistFinancialAsync(CancellationToken token = default, int expected = 1)
        => (await _financialRelationalContext.SaveChangesAsync(token) >= expected);

    public string FriendlyName(PixTypeEnum type)
    {
        var output = "";

        switch(type)
        {
            case PixTypeEnum.Cpf:       output = "Cpf";         break;
            case PixTypeEnum.Cnpj:      output = "Cnpj";        break;
            case PixTypeEnum.Email:     output = "Email";       break;
            case PixTypeEnum.Phone:     output = "Celular";     break;
            case PixTypeEnum.Random:    output = "Aleatória";   break;
        }

        return output;
    }
}