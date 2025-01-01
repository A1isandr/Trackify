using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Trackify.Contexts;
using Trackify.Helpers;
using Trackify.Models;
using Trackify.Services;
using Trackify.Services.Interfaces;
// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IIdentityService identityService) : Controller
{
    private readonly IIdentityService _identityService = identityService;
    
    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] GenerateTokenRequest request)
    {
        try
        {
            var token = _identityService.GenerateToken(request);
            
            var response = new
            {
                accessToken = token,
                username = request.Username
            };
            
            return Json(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}