using Core.Exceptions.Users;
using HotChocolate.Resolvers;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.AuthorizationMethod;

public static class AuthorizationMethod
{
    
    public static IObjectFieldDescriptor RequiredInternalRoles(this IObjectFieldDescriptor descriptor, string[] permission)
    {
        descriptor.Use((FieldMiddleware) (next => (FieldDelegate) (async context =>
        {

            var httpContextAccessorService = context.Services.GetRequiredService<IHttpContextAccessorService>();
            var jwtTokenWithBearer = httpContextAccessorService.GetRequestHeader("Authorization");
            var internalAuthService = context.Services.GetRequiredService<IAuthorizationService>();
            if (jwtTokenWithBearer == null || !jwtTokenWithBearer.Contains("Bearer") || jwtTokenWithBearer.Replace("Bearer", "").Trim().Length == 0)
            {
                throw new UnauthorizedException(nameof (AuthorizationMethod), nameof (RequiredInternalRoles), "No valid Authorization Bearer token");
            }       
            string jwt = jwtTokenWithBearer.Replace("Bearer", "").Trim();
            JwtValidationResponse response =  internalAuthService.ValidateJwtAsync(jwt);
            if (response == null)
            {
                // loggerService.LogFatal("Authentication result is FAILED", nameof (RequiredInternalRoles), "/Volumes/macData/Projects/nobisoft/nobisoft.core/Nobisoft.Core.Authorization/Methods/AuthorizationMethods.cs", 74);
                throw new UnauthorizedException(nameof (AuthorizationMethod), nameof (RequiredInternalRoles), "Unable to authenticate your request with error code " );
            }
            
            await next(context);
        })));
        return descriptor;
    }
}