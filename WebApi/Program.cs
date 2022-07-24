using System.Reflection;
using AppAny.HotChocolate.FluentValidation;
using Application.Graphql.Mutations;
using Application.Graphql.Queries;
using AutoMapper.Extensions.ExpressionMapping;
using Core.Configurations;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApi;

var builder = WebApplication.CreateBuilder(args);




var appDb = builder.Configuration.GetSection("AppDb").Get<AppDbConfiguration>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(option =>
{
    option.UseNpgsql($"Server={appDb.Server};Port={appDb.Port};User Id={appDb.UserName};Password={appDb.Password};Database={appDb.Database}");
    option.UseLoggerFactory(LoggerFactory.Create(loggingBuilder => { loggingBuilder.AddConsole(); }
    ));
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication(builder.Configuration);
#region  Services


builder.Services.AddHttpContextAccessor();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapGraphQL();
app.MapControllers();

app.Run();