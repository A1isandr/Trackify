using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}