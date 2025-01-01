using System.ComponentModel.DataAnnotations;

namespace Trackify.Models;

public class Category
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(100)]
    public required string Name { get; set; }
    
    public Board? Board { get; set; }
    
    public List<Card> Cards { get; set; } = [];
}