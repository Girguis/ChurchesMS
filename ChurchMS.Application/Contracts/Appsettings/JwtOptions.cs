namespace ChurchMS.Application.Contracts.Appsettings;

public class JwtOptions
{
    public static string Key { get; set; }
    public static string Audience { get; set; }
    public static string Issuer { get; set; }
    public static int ExpireTimeInHours { get; set; }
}