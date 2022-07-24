using Application.Graphql.ObjectTypes;

namespace Application.Graphql.Input.Users;

public class SignInByEmailInput:  InputObjectType<SignInByEmailObjectType>
{
    protected override void Configure(IInputObjectTypeDescriptor<SignInByEmailObjectType> descriptor)
    {
        descriptor.Description("test");
        descriptor.Field(f => f.Password).Description("Password is require");
        descriptor.Field(f => f.Email).Description("Email is require");
        base.Configure(descriptor);
    }
}