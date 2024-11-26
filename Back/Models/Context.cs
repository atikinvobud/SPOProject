using Microsoft.EntityFrameworkCore; // Для DbContext, ModelBuilder, DbSet и Entity Framework Core

namespace Back.Models;
class Context : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public Context(DbContextOptions<Context> options): base(options)
    {
        Database.EnsureCreated();
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                new User { Id=1, Name = "Tom", Surname = "aaa" },
                new User { Id=2, Name = "Bob", Surname = "vvv" },
                new User { Id=3, Name = "Sam", Surname = "ddd" }
        );
    }*/

}