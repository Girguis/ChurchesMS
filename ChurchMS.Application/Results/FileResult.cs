using System.Net;

namespace ChurchMS.Application.Results;

public sealed class FileResult : Result
{
    public byte[] FileContent { get; }
    public string ContentType { get; }
    public string FileName { get; }

    private FileResult()
    {

    }

    public FileResult(Exception exception) : base(exception)
    {
    }

    protected FileResult(HttpStatusCode statusCode, byte[] fileContent, string contentType, string fileName) : base(statusCode)
    {
        FileContent = fileContent;
        ContentType = contentType;
        FileName = fileName;
    }

    protected FileResult(HttpStatusCode statusCode, string errorCode) : base(statusCode, errorCode)
    {
    }

    protected FileResult(HttpStatusCode statusCode, string errorCode, object errors) : base(statusCode, errorCode, errors)
    {
    }

    public static FileResult Success(MemoryStream fileContent, string contentType, string fileName, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var fileContentAsByteArray = fileContent.ToArray();

        return new FileResult(statusCode, fileContentAsByteArray, contentType, fileName);
    }

    public static FileResult Success(byte[] fileContent, string contentType, string fileName, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new FileResult(statusCode, fileContent, contentType, fileName);
    }

    public static FileResult Failure(HttpStatusCode statusCode, string errorCode)
    {
        return new FileResult(statusCode, errorCode);
    }

    public static FileResult Failure(HttpStatusCode statusCode, string errorCode, object errors)
    {
        return new FileResult(statusCode, errorCode, errors);
    }

    public static FileResult CreateException(Exception exception)
    {
        return new FileResult(exception);
    }
}