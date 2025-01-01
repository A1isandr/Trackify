using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

[ApiController]
public class PagesController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return PhysicalFile(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"),
 "text/html");
    }
    
    [HttpGet("auth")]
    public IActionResult Auth()
    {
        return PhysicalFile(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "authorize.html"),
 "text/html");
    }
}