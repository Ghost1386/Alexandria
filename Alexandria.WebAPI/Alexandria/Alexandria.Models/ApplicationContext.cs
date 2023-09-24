using Alexandria.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Modification> ModeModifications { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
}