using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Trackify.Helpers;
using Trackify.Models;
using Trackify.Services.Interfaces;
// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Services;

public class TokenService(IUserService userService, PasswordHelper passwordHelper) : ITokenService
{
    private readonly IUserService _userService = userService;
    private readonly PasswordHelper _passwordHelper = passwordHelper;
    
    public string GenerateToken(GenerateTokenRequest request)
    {
        var user = _userService.GetByUsername(request.Username);

        if (user is null ||
            !_passwordHelper.VerifyPassword(user, user.HashedPassword!, request.Password))
        {
            throw new Exception("Invalid username or password");
        }
        
        var claims = new List<Claim> { new (ClaimTypes.Name, request.Username) };
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                AuthOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}