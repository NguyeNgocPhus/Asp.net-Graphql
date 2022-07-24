using Application.Graphql.ObjectTypes;

namespace Application.Graphql.Input.Users;

public class CreateUserInput: InputObjectType<CreateUserObjectType>
{
    protected override void Configure(IInputObjectTypeDescriptor<CreateUserObjectType> descriptor)
    {
        descriptor.Description("test");
        descriptor.Field(f => f.Name).Description("name is require");
        descriptor.Field(f => f.Email).Description("Email is require");
        base.Configure(descriptor);
    }
}