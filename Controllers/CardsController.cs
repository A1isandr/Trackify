using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}