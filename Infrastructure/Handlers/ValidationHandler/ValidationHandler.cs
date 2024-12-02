using System.Text.RegularExpressions;

namespace Monetizacao.Providers.Handlers;

public class ValidationHandler
{
    private readonly Regex _guidValidator;

    public ValidationHandler()
        => _guidValidator = new Regex(@"^[A-Fa-f0-9]{8}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{12}$");

    public bool IsEmailValid(string data)
    {
        if (!data.Contains("@") && !data.Contains("."))
            return false;

        return true;
    }

    public bool IsPasswordValid(string data)
    {
        if (data.Length < 6)
            return false;

        return true;
    }

    public bool IsIdValid(int? id)
    {
        if (!id.HasValue || id <= 0)
            return false;

        return true;
    }

    public bool IsIdValid(long? id)
    {
        if (!id.HasValue || id <= 0)
            return false;

        return true;
    }

    public bool IsIdsValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        if (data!.Length > 1 && !data.Contains(","))
            return false;

        return true;
    }

    public bool IsStampValid(string? data)
    {
        if (!IsStringValid(data) || !_guidValidator.IsMatch(data!))
            return false;

        return true;
    }

    public bool IsCpfValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        return (data!.Contains(".") && !data.Contains("/") && data.Contains("-"));
    }

    public bool IsCnpjValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        return (data!.Contains(".") && data.Contains("/") && data.Contains("-"));
    }

    public bool IsPhoneValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        return (data!.Contains("(") && data.Contains(")"));
    }

    public bool IsPixRandomKeyValid(string? data)
    {
        if (!IsStringValid(data) || data!.Length != 36)
            return false;

        return true;
    }
    
    public bool IsActionValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        return data!.EndsWith("?");
    }

    public bool IsPictureValid(string? data)
    {
        if (!IsStringValid(data) || data!.Length <= 8)
            return false;

        var slice = data.Substring(0, 8);

        if (!slice.ToLower().Equals("https://"))
            return false;

        return true;
    }

    public bool IsActionPeriodValid(DateTime starts, DateTime ends)
    {
        var diff = (ends - starts);

        if (diff.TotalSeconds <= 0)
            return false;

        return true;
    }

    public bool IsStringValid(string? data)
    {
        if (String.IsNullOrEmpty(data) || String.IsNullOrWhiteSpace(data))
            return false;

        return true;
    }

    public bool IsDateStringValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        data = data!.Replace("/", "").Replace(" ", "");

        if (!IsStringValid(data))
            return false;

        return true;
    }

    public bool IsTimeStringValid(string? data)
    {
        if (!IsStringValid(data))
            return false;

        data = data!.Replace(":", "").Replace("M", "").Replace(" ", "");

        if (!IsStringValid(data))
            return false;

        return true;
    }

    public bool IsTemplateValid(string data)
    {
        if (data.Length == 2)
            return false;

        if (!data.Contains("{") && !data.Contains("}"))
            return false;

        return true;
    }
}