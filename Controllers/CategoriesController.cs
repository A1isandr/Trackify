using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : Controller
{
    [HttpPost("create")]
    public IActionResult Index()
    {
        return Ok();
    }
}