using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class FormatConfiguration : IEntityTypeConfiguration<Format>
{
    public void Configure(EntityTypeBuilder<Format> builder)
    {
        builder.HasKey(f => f.Id);

        builder.HasMany(f => f.Tournaments)
               .WithOne(t => t.Format);
    }
}