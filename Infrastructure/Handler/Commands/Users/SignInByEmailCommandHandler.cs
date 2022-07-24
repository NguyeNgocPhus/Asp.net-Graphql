using Application.Commands.Users;
using Application.Dtos.Responses;
using Application.Queries.Users;
using Core.Exceptions.Users;
using Infrastructure.Common;
using Infrastructure.Databases;
using Infrastructure.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handler.Commands.Users;

public class SignInByEmailCommandHandler:IRequestHandler<SignInByEmailCommand,SignInResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IAuthorizationService _jwtService;
    private readonly IMediator _mediator;


    public SignInByEmailCommandHandler(ApplicationDbContext dbContext, IMediator mediator, IAuthorizationService jwtService)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _jwtService = jwtService;
    }

    public  async Task<SignInResponse> Handle(SignInByEmailCommand command, CancellationToken cancellationToken)
    {
        var query = new GetUserByEmailQuery()
        {
            Email = command.Email
        };
        var user = await _mediator.Send(query, cancellationToken);
        if (user == null)
        {
            throw new NotFoundUserException(nameof(SignInByEmailCommandHandler), nameof(SignInByEmailCommand), "Not found user");
        }

        if (user.Password != command.Password)
        {
            throw new NotFoundUserException(nameof(SignInByEmailCommandHandler), nameof(SignInByEmailCommand), "password incorrect");
        }

        var claims = Helper.BuildDefaultClaimsIdentity(user.Id.ToString(), user.Email, user.Name, "ADMIN");
        var tokenResponse = _jwtService.GenerateJwtAsync(claims, cancellationToken);

        return new SignInResponse()
        {
            Token = tokenResponse.accessToken,
            RefreshToken = tokenResponse.refeshToken,
            Id = user.Id,
            Success = true
        };
    }
}