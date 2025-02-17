using Trackify.Models;
using Trackify.Models.DTOs;

namespace Trackify.Mappers;

public static class BoardExtensions
{
    public static BoardMenuItem ToBoardMenuItem(this Board board)
    {
        return new BoardMenuItem
        {
            Id = board.Id,
            Name = board.Name
        };
    }
    
    public static SelectedBoard ToSelectedBoard(this Board board)
    {
        return new SelectedBoard
        {
            Id = board.Id,
            Categories = board.Categories
                .Select(category => category.ToCategoryMenuItem())
                .ToList()
        };
    }
}