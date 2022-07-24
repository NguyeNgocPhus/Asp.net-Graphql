using Application.Graphql.Resolver;

namespace Infrastructure.Graphql.Queries;

public class UserQuery: ObjectTypeExtension<RootQuery>
{
    protected override void Configure(IObjectTypeDescriptor<RootQuery> descriptor)
    {
        descriptor.Field("getToken")
            .Description("test query")
            .Type<StringType>()
            .ResolveWith<IUserResolver>(resolve => resolve.GetTokenAsync(default));
    }
}