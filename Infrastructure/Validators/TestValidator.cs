using Application.Graphql.ObjectTypes;
using FluentValidation;

namespace Infrastructure.Validators;

public class TestValidator : AbstractValidator<TestObjectType>
{
    public TestValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai name");
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai email");
        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai password");
    }
}