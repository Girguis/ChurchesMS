namespace ChurchMS.Application.Constants;

public class NotFoundErrors
{
    private static string NotFound(string propertyName) => $"NotFound{propertyName}";
    public string City => NotFound(nameof(City));
    public string District => NotFound(nameof(District));
    public string Street => NotFound(nameof(Street));
}