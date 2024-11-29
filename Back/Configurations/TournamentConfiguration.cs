using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasMany(t => t.Requests)
               .WithOne(r => r.Tournament);
        
        builder.HasOne(t => t.Date)
               .WithOne(d => d.Tournament)
               .HasForeignKey<Tournament>(t => t.DateId);

        builder.HasOne(t => t.Location)
               .WithMany(l => l.Tournaments)
               .HasForeignKey(t => t.LocationId);

        builder.HasOne(t => t.Sport)
               .WithMany(s => s.Tournaments)
               .HasForeignKey(t => t.SportId);
        
        builder.HasOne(t => t.Format)
               .WithMany(f => f.Tournaments)
               .HasForeignKey(t => t.FormatId);

        builder.HasOne(t => t.Notification)
               .WithOne(n => n.Tournament)
               .HasForeignKey<Tournament>(t => t.NotificationId);
    }
}