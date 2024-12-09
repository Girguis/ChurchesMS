namespace ChurchMS.Application.Contracts.Helper;

public interface IFileHelper
{
    byte[] GetFileBytes(string path);
}