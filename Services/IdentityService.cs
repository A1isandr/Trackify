using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Trackify.Helpers;
using Trackify.Models;
using Trackify.Services.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Services;

public class IdentityService(
    IUserService userService,
    IConfiguration configuration,
    PasswordHelper passwordHelper) : IIdentityService
{
    private readonly IUserService _userService = userService;
    private readonly IConfiguration _configuration = configuration;
    private readonly PasswordHelper _passwordHelper = passwordHelper;
    
    private static readonly TimeSpan TokenExpirationMinutes = TimeSpan.FromMinutes(2);
    
    public string GenerateToken(GenerateTokenRequest request)
    {
        var user = _userService.GetByUsername(request.Username);

        if (user is null ||
            !_passwordHelper.VerifyPassword(user, user.HashedPassword!, request.Password))
        {
            throw new Exception("Invalid username or password");
        }
        
        var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!);
        
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, request.Username)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenExpirationMinutes),
            NotBefore = DateTime.UtcNow,
            IssuedAt = DateTime.UtcNow,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}