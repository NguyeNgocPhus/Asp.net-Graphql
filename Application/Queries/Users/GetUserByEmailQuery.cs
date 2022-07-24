using Application.Dtos;
using MediatR;

namespace Application.Queries.Users;

public class GetUserByEmailQuery : IRequest<UserDto>
{
    public string Email { get; set; }
}