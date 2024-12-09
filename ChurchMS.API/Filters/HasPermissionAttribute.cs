using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ChurchMS.API.Filters;

public class HasPermissionAttribute : Attribute, IAuthorizationFilter
{
    private readonly PermissionsEnum _permission;
    private readonly ObjectResult _forbidenObjectResult;

    public HasPermissionAttribute(PermissionsEnum permission)
    {
        _permission = permission;
        _forbidenObjectResult = new ObjectResult(new ErrorDto() { ErrorCode = ErrorCodes.Unauthorized })
        {
            StatusCode = (int)HttpStatusCode.Forbidden
        };
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //if (!context.HttpContext.Items.TryGetValue(ClaimsTypes.Permissions, out object? permissions) || permissions == null)
        //{
        //    context.Result = _forbidenObjectResult;
        //    return;
        //}

        //if (!((List<string>)permissions).Any(x => x.Equals(((int)PermissionsEnum.FullAccess).ToString()) ||
        //                                            x.Equals(((int)_permission).ToString())))
        //{
        //    context.Result = _forbidenObjectResult;
        //    return;
        //}
    }
}