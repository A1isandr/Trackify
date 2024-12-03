using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

public class PagesController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }
    
    [HttpGet("/authorize")]
    public IActionResult Authorize()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "authorize.html"), "text/html");
    }

    // Доска или панель
    [HttpGet("/board")]
    public IActionResult Board()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "board.html"), "text/html");
    }
}