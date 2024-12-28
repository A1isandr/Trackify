using Trackify.Contexts;
using Trackify.Helpers;
using Trackify.Models;
using Trackify.Services.Interfaces;

namespace Trackify.Services;

public class UserService(ApplicationContext db, PasswordHelper passwordHelper) : IUserService
{
    // ReSharper disable ReplaceWithPrimaryConstructorParameter
    private readonly ApplicationContext _db = db;
    private readonly PasswordHelper _passwordHelper = passwordHelper;
    
    public User? GetByUsername(string username) => 
        _db.Users.FirstOrDefault(u => u.Username == username);
    
    public User? GetById(int id) => 
        _db.Users.FirstOrDefault(u => u.Id == id);

    public void Create(RegisterUserRequest request)
    {
        ArgumentNullException.ThrowIfNull(request.Username);
        ArgumentNullException.ThrowIfNull(request.Password);
        
        if (GetByUsername(request.Username) != null)
            throw new Exception("User with this username already exists");

        var user = new User {Username = request.Username};
        
        user.HashedPassword = _passwordHelper.GenerateHash(user, request.Password);
        
        _db.Users.Add(user);
        _db.SaveChanges();
    }
}