using Microsoft.EntityFrameworkCore; // Для DbContext, ModelBuilder, DbSet и Entity Framework Core

namespace Back.Models;
 public class Context : DbContext
{
    /*
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Date> Dates { get; set; } = null!;
    public DbSet<FavouriteSport> FavouriteSports { get; set; } = null!;
    public DbSet<Format> Formats { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Request> Requests { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Sport> Sports { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<TeamUsers> TeamsUsers { get; set; } = null!;
    public DbSet<Tournament> Tournaments { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserInfo> UserInfos { get; set; } = null!;
*/
    public DbSet<User> Users { get; set; } = null!;
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                new User { Id=2, Name = "Tom", Surname = "aaa" },
                new User { Id=3, Name = "Bob", Surname = "vvv" },
                new User { Id=4, Name = "Sam", Surname = "ddd" }
        );
    }*/

}