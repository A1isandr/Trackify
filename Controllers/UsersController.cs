using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackify.Models;
using Trackify.Services.Interfaces;
// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;
    
    [HttpPost("create")]
    [AllowAnonymous]
    public IActionResult Create([FromBody] CreateUserRequest request)
    {
        try
        {
            _userService.CreateAsync(request);
            return Accepted();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}