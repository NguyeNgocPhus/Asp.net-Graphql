using Application.Commands;
using Application.Dtos.Responses;
using Application.Queries.Users;
using Core.Exceptions.Users;
using Core.ReadModels;
using Infrastructure.Databases;
using MediatR;

namespace Infrastructure.Handler.Commands.Users;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,CreateUserResponse>
{
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _dbContext;

    public CreateUserCommandHandler(IMediator mediator, ApplicationDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var query = new GetUserByEmailQuery()
        {
            Email = command.Email
        };
        var existUser = await _mediator.Send(query, cancellationToken);
        if (existUser != null)
        {
            throw new DuplicateUserException(nameof(CreateUserCommandHandler), nameof(CreateUserCommand), "DUplicate email");
        }
        const string passwordDefault = "Abc@12345";
        var user = new UserReadModel()
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            Name = command.Name,
            Password = passwordDefault
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        

        return new CreateUserResponse()
        {
            Id = user.Id,
            Success = true
        };


    }
}