using Application.Dtos;
using Application.Queries.Users;
using Application.Repositories;
using MediatR;

namespace Infrastructure.Handler.Queries;

public class UserQueryHandler :
    IRequestHandler<GetUserByEmailQuery,UserDto?>
{

    private readonly IUsersRepository _usersRepository;

    public UserQueryHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserDto?> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetUserByEmail(query.Email, cancellationToken);
    }
}