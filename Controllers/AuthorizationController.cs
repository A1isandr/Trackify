using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

public class AuthorizationController : Controller
{
    [HttpGet("/login")]
    public IActionResult Index()
    {
        return View();
    }
}