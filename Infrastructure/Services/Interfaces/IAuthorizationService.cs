using System.Security.Claims;
using Infrastructure.Services.Response;

namespace Infrastructure.Services.Interfaces;

public interface IAuthorizationService
{
    JwtValidationResponse ValidateJwtAsync(
        string jwt,
        CancellationToken cancellationToken = default (CancellationToken));

    GenerateJwtResponse GenerateJwtAsync( ClaimsIdentity claimsIdentity, CancellationToken cancellationToken);

}