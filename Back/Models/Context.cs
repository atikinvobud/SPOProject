using Back.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Back.Models;
 public class Context : DbContext
{
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
<<<<<<< HEAD
=======

>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}