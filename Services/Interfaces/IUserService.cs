using Trackify.Models;

namespace Trackify.Services.Interfaces;

public interface IUserService
{
    public User? GetByUsername(string username);
    public User? GetById(int id);
    public void Create(RegisterUserRequest request);
}