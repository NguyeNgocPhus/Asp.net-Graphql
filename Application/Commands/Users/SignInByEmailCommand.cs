using Application.Dtos.Responses;
using MediatR;

namespace Application.Commands.Users;

public class SignInByEmailCommand: IRequest<SignInResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}