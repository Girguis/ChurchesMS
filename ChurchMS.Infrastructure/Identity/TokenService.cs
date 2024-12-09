using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Appsettings;
using ChurchMS.Application.Contracts.Identity;
using ChurchMS.Application.Enums;
using ChurchMS.Application.Results;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ChurchMS.Infrastructure.Identity;

public sealed class TokenService : ITokenService
{
    private static readonly string _issuer = JwtOptions.Issuer;
    private static readonly string _audience = JwtOptions.Audience;
    private static readonly int _expireTime = JwtOptions.ExpireTimeInHours;
    private static readonly byte[] _key = Encoding.ASCII.GetBytes(JwtOptions.Key);
    private static readonly EncryptingCredentials _encryptingCredentials = new(new SymmetricSecurityKey(_key),
                                                                                   SecurityAlgorithms.Aes256KW,
                                                                                   SecurityAlgorithms.Aes256CbcHmacSha512);

    public Result<string> Generate(UserModel user)
    {
        try
        {
            var claims = new List<Claim>()
            {
                new(ClaimsTypes.UserGuid, user.Guid),
                new(ClaimsTypes.ChurchGuid, user.ChurchGuid )
            };

            claims.AddRange(user.Permissions.Select(x => new Claim(ClaimsTypes.Permissions, x.ToString())));
            IdentityModelEventSource.ShowPII = true;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_expireTime),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key),
                                                                SecurityAlgorithms.HmacSha256),
                EncryptingCredentials = _encryptingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var result = tokenHandler.WriteToken(token);

            return Result<string>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<string>.CreateException(ex);
        }
    }

    public Result<List<Claim>> GetClaims(string token)
    {
        try
        {
            var (Status, Principal) = ExtractToken(token);
            if (Status != TokenStatus.Valid)
                return Result<List<Claim>>.Failure(HttpStatusCode.Unauthorized, ErrorCodes.Unauthorized);

            return Result<List<Claim>>.Success(Principal.Claims.ToList());
        }
        catch (Exception ex)
        {
            return Result<List<Claim>>.CreateException(ex);
        }
    }

    private static (TokenStatus Status, ClaimsPrincipal Principal) ExtractToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(_key),
                LifetimeValidator = LifetimeValidator,
                TokenDecryptionKey = _encryptingCredentials.Key
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            return (TokenStatus.Valid, principal);
        }
        catch (Exception ex)
        {
            var tokenStatus = ex.Message.Contains("IDX10223") ? TokenStatus.Expired : TokenStatus.Invalid;
            return (tokenStatus, null);
        }
    }

    private static bool LifetimeValidator(DateTime? notBefore,
                                          DateTime? expires,
                                          SecurityToken securityToken,
                                          TokenValidationParameters validationParameters)
        => expires != null && expires > DateTime.UtcNow;
}