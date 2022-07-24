using Application.Graphql.ObjectTypes;

namespace Application.Graphql.Input;

public class TestInput : InputObjectType<TestObjectType>
{
    protected override void Configure(IInputObjectTypeDescriptor<TestObjectType> descriptor)
    {
        descriptor.Description("test");
        descriptor.Field(f => f.Name).Description("name is require");
        descriptor.Field(f => f.Password).Description("name is login");
        descriptor.Field(f => f.Email).Description("Email is require");
        base.Configure(descriptor);
    }
}