using AppAny.HotChocolate.FluentValidation;
using Application.Dtos.Responses;
using Application.Graphql.Input;
using Application.Graphql.Input.Users;
using Application.Graphql.Resolver;
using Infrastructure.Common.AuthorizationMethod;
using Infrastructure.Validators;
using Infrastructure.Validators.Users;

namespace Infrastructure.Graphql.Mutations;

public class UserMutation: ObjectTypeExtension<RootMutation>
{
    protected override void Configure(IObjectTypeDescriptor<RootMutation> descriptor)
    {
        descriptor.Field("createUser")
            .Description("create user")
            .RequiredInternalRoles(new []{"ADMIN"})
            .Type<ObjectType<CreateUserResponse>>()
            .Argument("objectType", desc =>
            {
                desc.Type<CreateUserInput>();
                desc.UseFluentValidation(builder => builder.UseValidator(typeof(CreateUserValidator)));
            })
            .ResolveWith<IUserResolver>(resolve => resolve.CreateUserAsync(default,default));
        descriptor.Field("SignInByEmail")
            .Description("sign in user")
            .RequiredInternalRoles(new []{"ADMIN"})
            .Type<ObjectType<SignInResponse>>()
            .Argument("objectType", desc =>
            {
                desc.Type<SignInByEmailInput>();
                desc.UseFluentValidation(builder => builder.UseValidator(typeof(SignInByEmailValidator)));
            })
            .ResolveWith<IUserResolver>(resolve => resolve.SignInByEmailAsync(default,default));
    }
}