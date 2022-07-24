using System.Reflection;
using AppAny.HotChocolate.FluentValidation;
using Application.Graphql.Resolver;
using Application.Repositories;
using Core.Configurations;
using FluentValidation.AspNetCore;
using Infrastructure.Graphql.Mutations;
using Infrastructure.Graphql.Queries;
using Infrastructure.Graphql.Resolvers;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjections
{

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidation(
            x => { x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); }
        );
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<ITestResolver, TestResolver>();
        services.AddScoped<IUserResolver, UserResolver>();
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddSingleton<IHttpContextAccessorService, HttpContextAccessorService>();
        services.AddSingleton<IAuthorizationService, AuthorizationService>();
        services.AddSingleton<IPasswordGeneratorService, PasswordGeneratorService>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        services.Configure<JwtConfiguration>(
            configuration.GetSection(nameof(JwtConfiguration)));
        // Add GraphQL
        services.AddGraphQLServer()
            .AddFluentValidation(x => { })
            .AddQueryType<RootQueryType>()
            .AddTypeExtension<TestQuery>()
            .AddTypeExtension<UserQuery>()
            .AddMutationType<RootMutationType>()
            .AddTypeExtension<TestMutation>()
            .AddTypeExtension<UserMutation>()
            ;
        // .AddFluentValidation(x => { })
            // .AddQueryType<RootQueryType>()
            // .AddTypeExtension<TestQuery>()
            // .AddMutationType<RootMutationType>()
            // .AddTypeExtension<TestMutation>();
            //.InitializeOnStartup();
        return services;
    }
}