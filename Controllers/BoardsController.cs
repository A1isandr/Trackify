using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackify.Contexts;
using Trackify.Models;
using Trackify.Models.DTOs;
using Trackify.Services.Interfaces;
// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]" )]
[Authorize]
public class BoardsController(IBoardService boardService) : Controller
{
    private readonly IBoardService _boardService = boardService;
    
    [HttpGet]
    public IActionResult GetBoardsList([FromQuery] int offset, [FromQuery] int limit) 
    {
        if (offset < 0 || limit < 0)
            return BadRequest("Offset and limit must be greater than 0");
        
        var boards = _boardService
            .GetByUsername(User.Identity!.Name!)
            .Skip(offset)
            .Take(limit);
        
        return Json(boards);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetBoard(Guid id)
    {
        var board = _boardService.GetByIdAsync(id);
        
        return Json(board);
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateBoard([FromBody] CreateBoardRequest request)
    {
        try
        {
            await _boardService.CreateAsync(request);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Accepted();
    }
}