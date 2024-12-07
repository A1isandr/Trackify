using Microsoft.AspNetCore.Mvc;
using Trackify.Models;

namespace Trackify.Controllers;

public class AuthorizationController : Controller
{
    [HttpPost("/api/login")]
    public IActionResult Login([FromBody] LoginCredentials credentials)
    {
        if (credentials.Username == "admin" || credentials.Password == "admin")
        {
            return Ok(new { message = $"Добро пожаловать, {credentials.Username}" });
        }
        
        return Unauthorized(new { message = "Неправильный логин или пароль" });
    }
}