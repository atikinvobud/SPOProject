using Back.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Back.Models;
 public class Context : DbContext
{
    // Это говно не работает с другим названием
    public DbSet<City> NotACities { get; set; } = null!;
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
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new DateConfiguration());
        modelBuilder.ApplyConfiguration(new FavouriteSportConfiguration());
        modelBuilder.ApplyConfiguration(new FormatConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new RequestConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new SportConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new TeamUsersConfiguration());
        modelBuilder.ApplyConfiguration(new TournamentConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}