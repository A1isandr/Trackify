using System.ComponentModel.DataAnnotations;

namespace Trackify.Models;

public class Card
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(100)]
    public required string Title { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public Category? Category { get; set; }
}