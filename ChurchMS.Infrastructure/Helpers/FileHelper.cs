using ChurchMS.Application.Contracts.Helper;

namespace ChurchMS.Infrastructure.Helpers;

public class FileHelper : IFileHelper
{
    public byte[] GetFileBytes(string filePath)
    {
        try
        {
            return File.ReadAllBytes(filePath);
        }
        catch
        {
            return [];
        }
    }
}