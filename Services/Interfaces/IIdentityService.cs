using Trackify.Models;

namespace Trackify.Services.Interfaces;

public interface IIdentityService
{
    public string GenerateToken(GenerateTokenRequest request);
}