using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.HasMany(l => l.Tournaments)
               .WithOne(t => t.Location);
        
        builder.HasOne(l => l.City)
               .WithMany(c => c.Locations)
               .HasForeignKey(l => l.CityId);
    }
}