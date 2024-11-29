using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class FavouriteSportConfiguration : IEntityTypeConfiguration<FavouriteSport>
{
    public void Configure(EntityTypeBuilder<FavouriteSport> builder)
    {
        builder.HasKey(fs => fs.Id);

        builder.HasMany(fs => fs.UserInfos)
               .WithMany(ui => ui.FavouriteSports);
    }
}