using Application.Dtos;
using Core.ReadModels;

namespace Application.Repositories;

public interface IUsersRepository
{
    Task<UserDto> CreateUserAsync(UserReadModel user, CancellationToken cancellationToken = default);
    Task<UserDto?> GetUserByEmail(string email, CancellationToken cancellationToken = default);
}