using System.ComponentModel.DataAnnotations;

namespace Trackify.Models;

public class Board
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(100)]
    public required string Name { get; set; }
    
    public User? Owner { get; set; }
    
    public List<Category> Categories { get; set; } = [];
}