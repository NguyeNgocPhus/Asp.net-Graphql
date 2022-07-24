using Application.Dtos;
using Application.Graphql.ObjectTypes;

namespace Application.Graphql.Resolver;

public  interface  ITestResolver
{
    public Task<TestDto> TestApiQueryAsync(CancellationToken cancellationToken = default);
    public Task<TestDto> TestApiMutationAsync( TestObjectType objectType,CancellationToken cancellationToken = default);
}