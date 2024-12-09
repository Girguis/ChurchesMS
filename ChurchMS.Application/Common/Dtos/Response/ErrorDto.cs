namespace ChurchMS.Application.Common.Dtos.Response;

public class ErrorDto
{
    public string ErrorCode { get; set; }
    public object Errors { get; set; }
}