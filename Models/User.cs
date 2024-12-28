using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace Trackify.Models;

public class User
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string? Username { get; set; }
    
    [MaxLength(100)]
    public string? HashedPassword { get; set; }
}