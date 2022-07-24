using Application.Graphql.ObjectTypes;
using FluentValidation;

namespace Infrastructure.Validators.Users;

public class SignInByEmailValidator: AbstractValidator<SignInByEmailObjectType>
{
    public SignInByEmailValidator()
    {
        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai Password");
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("sai email");
    }
}