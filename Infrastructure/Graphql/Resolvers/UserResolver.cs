using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Commands;
using Application.Commands.Users;
using Application.Dtos.Responses;
using Application.Graphql.ObjectTypes;
using Application.Graphql.Resolver;
using AutoMapper;
using Core.Configurations;
using Infrastructure.Common;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Graphql.Resolvers;

public class UserResolver : IUserResolver
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly JwtConfiguration _jwtOption;

    public UserResolver(IMediator mediator, IMapper mapper,IOptions<JwtConfiguration> jwtOption)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtOption = jwtOption.Value;
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserObjectType objectType, CancellationToken cancellationToken = default)
    {
        try
        {
            var command = _mapper.Map<CreateUserCommand>(objectType);
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<SignInResponse> SignInByEmailAsync(SignInByEmailObjectType objectType,  CancellationToken cancellationToken = default)
    {
        try
        {
            var command = _mapper.Map<SignInByEmailCommand>(objectType);
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var claims = new[]
            {
                new Claim(JwtClaimTypes.Email, "phu@gmail.com"),
                new Claim(JwtClaimTypes.Name, "Phu"),
                new Claim(JwtClaimTypes.UserId, Guid.NewGuid().ToString()), 
                new Claim(JwtClaimTypes.Permission, "SUPPERADMIN")
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOption.SymmetricSecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOption.Audience,
                Issuer = _jwtOption.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jwtOption.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            await Task.CompletedTask;
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return token;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       

    }
}