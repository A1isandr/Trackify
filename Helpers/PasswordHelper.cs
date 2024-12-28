using Microsoft.AspNetCore.Identity;
using Trackify.Models;

namespace Trackify.Helpers;

public class PasswordHelper(IPasswordHasher<User> passwordHasher)
{
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    
    public string GenerateHash(User user, string password) => 
        _passwordHasher.HashPassword(user, password);

    public bool VerifyPassword(User user, string hashedPassword, string password) =>
        _passwordHasher.VerifyHashedPassword(user, hashedPassword, password) == PasswordVerificationResult.Success;
}