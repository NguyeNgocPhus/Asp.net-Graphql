using System.Security.Claims;

namespace Infrastructure.Common;

public static  class Helper
{
    public static ClaimsIdentity BuildDefaultClaimsIdentity(
        string Id,
        string Email,
        string Name,
        string Permssion)
    {
        List<Claim> claimList = new List<Claim>();
        claimList.Add(new Claim(JwtClaimTypes.Id, Id));
        claimList.Add(new Claim(JwtClaimTypes.Email, Email));
        claimList.Add(new Claim(JwtClaimTypes.Name, Name));
        claimList.Add(new Claim(JwtClaimTypes.Permission, Permssion));
        return new ClaimsIdentity((IEnumerable<Claim>) claimList);
    }
}