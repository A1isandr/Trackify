using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Trackify.Contexts;
using Trackify.Models;
using Trackify.Services;
using Trackify.Services.Interfaces;
using Trackify.Validation;

namespace Trackify.Helpers.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBoardService, BoardService>();

        services.AddTransient<PasswordHelper>();
    }
    
    public static void AddValidationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
        services.AddValidatorsFromAssemblyContaining<BoardValidator>();
        services.AddValidatorsFromAssemblyContaining<CardValidator>();
        services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
    }
}