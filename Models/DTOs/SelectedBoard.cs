namespace Trackify.Models.DTOs;

public class SelectedBoard
{
    public required Guid Id { get; init; }
    
    public required List<CategoryMenuItem> Categories { get; init; }
}