using Application.Dtos;
using Application.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.ReadModels;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;


    public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public Task<UserDto> CreateUserAsync(UserReadModel user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto?> GetUserByEmail(string email, CancellationToken cancellationToken = default)
    {
        return await  _dbContext.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Email.Equals(email), cancellationToken);
    }
}