using Trackify.Models;
using Trackify.Models.DTOs;

namespace Trackify.Services.Interfaces;

public interface IUserService
{
    public User? GetByUsername(string username);
    public Task CreateAsync(CreateUserRequest request);
}