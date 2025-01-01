using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Trackify.Models;

[PrimaryKey("Username")]
public class User
{
    [MaxLength(100)]
    public required string Username { get; init; }
    
    [MaxLength(100)]
    public string? HashedPassword { get; set; }

    public List<Board> Boards { get; set; } = [];
}