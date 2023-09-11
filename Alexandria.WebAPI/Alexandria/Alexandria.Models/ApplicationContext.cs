using Alexandria.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Token> Tokens { get; set; }
}