using Microsoft.EntityFrameworkCore;
using Trackify.Contexts;
using Trackify.Helpers;
using Trackify.Models;
using Trackify.Models.DTOs;
using Trackify.Services.Interfaces;
// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Services;

public class UserService(ApplicationContext db, PasswordHelper passwordHelper) : IUserService
{
    private readonly ApplicationContext _db = db;
    private readonly PasswordHelper _passwordHelper = passwordHelper;
    
    public async Task<User?> GetByUsernameAsync(string username) => 
        await _db.Users
            .FirstOrDefaultAsync(u => u.Username == username);

    public async Task CreateAsync(CreateUserRequest request)
    {
        ArgumentNullException.ThrowIfNull(request.Username);
        ArgumentNullException.ThrowIfNull(request.Password);
        
        if (await GetByUsernameAsync(request.Username) != null)
            throw new Exception("User with this username already exists");

        var user = new User { Username = request.Username };
        
        user.HashedPassword = _passwordHelper.GenerateHash(user, request.Password);
        
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }
}