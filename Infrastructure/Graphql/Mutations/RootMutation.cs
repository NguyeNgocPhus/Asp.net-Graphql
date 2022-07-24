using Application.Graphql.Mutations;

namespace Infrastructure.Graphql.Mutations;

public class RootMutation:IRootMutation
{
    
}

public class RootMutationType : ObjectType<RootMutation>
{
    protected override void Configure(IObjectTypeDescriptor<RootMutation> descriptor)
    {
        descriptor.Name("RootMutation");
        descriptor.Description("Root Mutation of the system");
    }
}