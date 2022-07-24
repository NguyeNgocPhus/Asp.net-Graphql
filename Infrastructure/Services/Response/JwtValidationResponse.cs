using System.Security.Claims;

namespace Infrastructure.Services.Response;

public class JwtValidationResponse
{
   public  ClaimsPrincipal Claim { get; set; }
}