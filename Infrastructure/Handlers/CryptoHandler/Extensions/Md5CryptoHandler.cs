using System.Security.Cryptography;
using System.Text;

namespace Monetizacao.Providers.Handlers;

public class Md5CryptoHandler : IDisposable
{
    private readonly MD5                _manager;
    private readonly StringBuilder      _sb;

    public Md5CryptoHandler()
    {
        _manager = MD5.Create();
        _sb = new StringBuilder();
    }

    public string Parse(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = _manager.ComputeHash(inputBytes);

        _sb.Clear();
        for (int i = 0; i < hashBytes.Length; i++)
            _sb.Append(hashBytes[i].ToString("X2"));

        return _sb.ToString();
    }

    public void Dispose()
    {
        _manager.Dispose();
        _sb.Clear();
    }
}
