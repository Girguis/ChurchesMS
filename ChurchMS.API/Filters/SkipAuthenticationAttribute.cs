using Microsoft.AspNetCore.Mvc.Filters;

namespace ChurchMS.API.Filters;

public class SkipAuthenticationAttribute : Attribute, IFilterMetadata
{

}