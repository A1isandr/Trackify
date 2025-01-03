using Trackify.Models;
using Trackify.Models.DTOs;

namespace Trackify.Services.Interfaces;

public interface IBoardService
{
    public Task<Board?> GetByIdAsync(Guid id);
    public IEnumerable<Board> GetByUsername(string username);
    public Task CreateAsync(CreateBoardRequest request);
}