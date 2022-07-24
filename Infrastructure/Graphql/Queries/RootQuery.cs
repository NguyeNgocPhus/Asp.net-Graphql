using Application.Graphql.Queries;
using Infrastructure.Graphql.Resolvers;

namespace Infrastructure.Graphql.Queries;

public class RootQuery : IRootQuery
{
    
}
public class RootQueryType : ObjectType<RootQuery>
{
    protected override void Configure(IObjectTypeDescriptor<RootQuery> descriptor)
    {
        descriptor.Name("RootQuery");
        descriptor.Description("Root Query of the system");
    }
}