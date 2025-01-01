using Trackify.Models;

namespace Trackify.Services.Interfaces;

public interface ITokenService
{
    public string GenerateToken(GenerateTokenRequest request);
}