using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.UserInfos)
               .WithOne(ui => ui.City);

        builder.HasMany(c => c.Locations)
               .WithOne(l => l.City);
    }
}