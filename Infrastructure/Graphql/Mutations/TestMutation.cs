using AppAny.HotChocolate.FluentValidation;
using Application.Dtos;
using Application.Graphql.Input;
using Application.Graphql.Resolver;
using Infrastructure.Validators;

namespace Infrastructure.Graphql.Mutations;

public class TestMutation : ObjectTypeExtension<RootMutation>
{
    protected override void Configure(IObjectTypeDescriptor<RootMutation> descriptor)
    {
        descriptor.Field("testTestMutation")
            .Description("test mutation")
            .Type<ObjectType<TestDto>>()
            .Argument("objectType", desc =>
            {
                desc.Type<TestInput>();
                desc.UseFluentValidation(builder => builder.UseValidator(typeof(TestValidator)));
            })
            .ResolveWith<ITestResolver>(resolve => resolve.TestApiMutationAsync(default,default));
    }
}