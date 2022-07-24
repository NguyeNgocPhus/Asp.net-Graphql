using Application.Dtos;
using Application.Graphql.Resolver;
using Infrastructure.Common.AuthorizationMethod;
using Infrastructure.Graphql.Resolvers;

namespace Infrastructure.Graphql.Queries;

public class TestQuery : ObjectTypeExtension<RootQuery>
{
    protected override void Configure(IObjectTypeDescriptor<RootQuery> descriptor)
    {
        descriptor.Field("testTestQuery")
            .Description("test query")
            .RequiredInternalRoles(new []{"hello"})
            .Type<ObjectType<TestDto>>()
            .ResolveWith<ITestResolver>(resolve => resolve.TestApiQueryAsync(default));
    }
}
// public class BookType : ObjectType<Book>
// {
//     protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
//     {
//         descriptor
//             .Field(f => f.Title)
//             .Type<StringType>();
//
//         descriptor
//             .Field(f => f.Author)
//             .Type<StringType>();
//     }
// }