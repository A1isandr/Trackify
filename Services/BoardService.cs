using Microsoft.EntityFrameworkCore;
using Trackify.Contexts;
using Trackify.Models;
using Trackify.Models.DTOs;
using Trackify.Services.Interfaces;
// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace Trackify.Services;

public class BoardService(ApplicationContext db, IUserService userService) : IBoardService
{
    private readonly ApplicationContext _db = db;
    private readonly IUserService _userService = userService;
    
    public async Task<Board?> GetByIdAsync(Guid id) =>
        await _db.Boards
            .FirstOrDefaultAsync(b => b.Id == id);

    public IEnumerable<Board> GetByUsername(string username) =>
        _db.Boards
            .Where(board => board.Owner!.Username == username);

    public async Task CreateAsync(CreateBoardRequest request)
    {
        ArgumentNullException.ThrowIfNull(request.Name);
        ArgumentNullException.ThrowIfNull(request.OwnerUsername);
        
        var owner = await _userService.GetByUsernameAsync(request.OwnerUsername);
        
        if (owner is null)
            throw new Exception("User with this username does not exist");
        
        var board = new Board
        {
            Name = request.Name, 
            Owner = owner
        };
        
        await _db.Boards.AddAsync(board);
        await _db.SaveChangesAsync();
    }
}