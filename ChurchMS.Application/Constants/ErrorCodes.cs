namespace ChurchMS.Application.Constants;

public class ErrorCodes
{
    public static string InternalServerError => nameof(InternalServerError);
    public static string ValidationError => nameof(ValidationError);
    public static string InvalidToken => nameof(InvalidToken);
    public static string Unauthorized => nameof(Unauthorized);
    public static NotFoundErrors NotFoundErrors => new();
}