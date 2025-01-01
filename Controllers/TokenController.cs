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
public class TokenController(ITokenService tokenService) : Controller
{
    private readonly ITokenService _tokenService = tokenService;
    
    [HttpPost("generate")]
    public IActionResult Generate([FromBody] GenerateTokenRequest request)
    {
        try
        {
            var token = _tokenService.GenerateToken(request);
            
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