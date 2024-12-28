using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Trackify.Models;

namespace Trackify.Helpers;

public class JwtHelper
{
    public static string GenerateToken(LoginCredentials credentials)
    {
        var claims = new List<Claim> { new (ClaimTypes.Name, credentials.Username) };
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(
                AuthOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}