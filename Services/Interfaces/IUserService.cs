using Trackify.Models;

namespace Trackify.Services.Interfaces;

public interface IUserService
{
    public User? GetByUsername(string username);
    public Task CreateAsync(CreateUserRequest request);
}