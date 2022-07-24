using Application.Graphql.ObjectTypes;
using FluentValidation;

namespace Infrastructure.Validators.Users;

public class CreateUserValidator: AbstractValidator<CreateUserObjectType>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai name");
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai email");
    }
}