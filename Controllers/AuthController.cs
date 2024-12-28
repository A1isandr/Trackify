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

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IUserService userService, 
    PasswordHelper passwordHelper,
    JwtHelper jwtHelper) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly PasswordHelper _passwordHelper = passwordHelper;
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginCredentials credentials)
    {
        var user = _userService.GetByUsername(credentials.Username);

        if (user is null ||
            !_passwordHelper.VerifyPassword(user, user.HashedPassword!, credentials.Password))
        {
            return Unauthorized("Invalid username or password");
        }
        
        var jwt = JwtHelper.GenerateToken(credentials);
        
        var response = new
        {
            accessToken = jwt,
            username = user.Username
        };
 
        return Json(response);
    }
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserRequest request)
    {
        try
        {
            _userService.Create(request);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok();
    }
}