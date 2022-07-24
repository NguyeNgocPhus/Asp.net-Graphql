using Application.Dtos.Responses;
using MediatR;

namespace Application.Commands;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public string Email { get; set; }
    public string Name { get; set; }
}