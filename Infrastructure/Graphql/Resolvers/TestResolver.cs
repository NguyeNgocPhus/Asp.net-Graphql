using Application.Dtos;
using Application.Graphql.ObjectTypes;
using Application.Graphql.Resolver;
using AutoMapper;

namespace Infrastructure.Graphql.Resolvers;

public class TestResolver :ITestResolver
{
    private readonly IMapper _mapper;
    

    public TestResolver(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<TestDto> TestApiQueryAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return new TestDto { Name  = "C# in depth", Email = "Jon Skeet",Code = "dcm"};
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    public async Task<TestDto> TestApiMutationAsync(TestObjectType objectType,  CancellationToken cancellationToken = default)
    {
        return new TestDto(){};
    }
}