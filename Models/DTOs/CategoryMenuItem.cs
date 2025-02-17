namespace Trackify.Models.DTOs;

public class CategoryMenuItem
{
    public required Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required List<Card> Cards { get; set; }
}