namespace ChurchMS.Application.Contracts.Ciphers;

public interface ICipher
{
    string Hash(string text);
}