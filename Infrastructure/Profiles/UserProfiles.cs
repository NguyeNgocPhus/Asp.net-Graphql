using Application.Commands;
using Application.Commands.Users;
using Application.Dtos;
using Application.Graphql.ObjectTypes;
using AutoMapper;
using Core.ReadModels;

namespace Infrastructure.Profiles;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<CreateUserObjectType, CreateUserCommand>();
        CreateMap<UserReadModel, UserDto>();
        CreateMap<SignInByEmailObjectType, SignInByEmailCommand>();
    }
}