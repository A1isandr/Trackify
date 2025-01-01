using Microsoft.AspNetCore.Identity;
using Trackify.Contexts;
using Trackify.Models;
using Trackify.Services;
using Trackify.Services.Interfaces;

namespace Trackify.Helpers.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddTransient<ApplicationContext>();
        services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBoardService, BoardService>();

        services.AddTransient<PasswordHelper>();
    }
}