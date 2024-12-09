using ChurchMS.Application.Contracts.Ciphers;
using System.Security.Cryptography;
using System.Text;

namespace ChurchMS.Infrastructure.Ciphers;

public class Cipher : ICipher
{
    public string Hash(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return plainText;

        byte[] bytes = SHA512.HashData(Encoding.UTF8.GetBytes(plainText));
        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
            builder.Append(bytes[i].ToString("x2"));

        return builder.ToString();
    }
}