using Trackify.Models;
using Trackify.Models.DTOs;

namespace Trackify.Services.Interfaces;

public interface IIdentityService
{
    public Task<string> GenerateTokenAsync(GenerateTokenRequest request);
}