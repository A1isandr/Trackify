using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackify.Models;
using Trackify.Models.DTOs;
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
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        try
        {
            await _userService.CreateAsync(request);
            return Accepted();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}