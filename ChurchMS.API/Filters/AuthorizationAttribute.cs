using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChurchMS.API.Filters;

public class AuthorizationAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.Filters.Contains(new SkipAuthenticationAttribute()))
            return;

        var token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString().Split(' ').LastOrDefault();
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new UnauthorizedObjectResult(new ErrorDto()
            {
                ErrorCode = ErrorCodes.Unauthorized,
            });

            return;
        }

        var tokenService = context.HttpContext.RequestServices.GetRequiredService<ITokenService>();
        var tokenClaimsResult = tokenService.GetClaims(token);

        if (!tokenClaimsResult.IsSuccess)
        {
            context.Result = new ObjectResult(null)
            {
                StatusCode = (int)tokenClaimsResult.StatusCode
            };

            return;
        }

        var claims = tokenClaimsResult.Data;
        var userGuid = claims.FirstOrDefault(x => x.Type == ClaimsTypes.UserGuid)?.Value;
        var churchGuid = claims.FirstOrDefault(x => x.Type == ClaimsTypes.ChurchGuid)?.Value;
        var permissions = claims.Where(x => x.Type == ClaimsTypes.Permissions).Select(x => x.Value).ToList();

        context.HttpContext.Items.Add(ClaimsTypes.UserGuid, userGuid);
        context.HttpContext.Items.Add(ClaimsTypes.ChurchGuid, churchGuid);
        context.HttpContext.Items.Add(ClaimsTypes.Permissions, permissions);
    }
}