using Application.Dtos.Responses;
using Application.Graphql.ObjectTypes;

namespace Application.Graphql.Resolver;

public interface IUserResolver
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserObjectType objectType, CancellationToken cancellationToken = default);
    Task<string> GetTokenAsync(CancellationToken cancellationToken = default);
    Task<SignInResponse> SignInByEmailAsync(SignInByEmailObjectType objectType, CancellationToken cancellationToken = default);

}