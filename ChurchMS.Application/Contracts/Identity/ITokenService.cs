using ChurchMS.Application.Results;
using System.Security.Claims;

namespace ChurchMS.Application.Contracts.Identity;

public interface ITokenService
{
    Result<string> Generate(UserModel guid);
    Result<List<Claim>> GetClaims(string token);
}

public class UserModel
{
    public string Guid { get; set; }
    public string ChurchGuid { get; set; }
    public List<int> Permissions { get; set; }
}