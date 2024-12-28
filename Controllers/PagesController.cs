using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

[ApiController]
public class PagesController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }
    
    [HttpGet("auth")]
    public IActionResult Authorize()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "authorize.html"), "text/html");
    }
    
    [HttpGet("board")]
    public IActionResult Board()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "board.html"), "text/html");
    }
}