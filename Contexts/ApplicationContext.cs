using Microsoft.EntityFrameworkCore;
using Trackify.Models;

namespace Trackify.Contexts;

public sealed class ApplicationContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Board> Boards { get; set; } = null!;

    public ApplicationContext(
        IConfiguration configuration)
    {
        _configuration = configuration;
        
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    }
}