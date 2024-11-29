using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(ui => ui.UserId);

        builder.HasOne(ui => ui.User)
               .WithOne(u => u.UserInfo)
               .HasForeignKey<UserInfo>(ui => ui.UserId);

        builder.HasOne(ui => ui.City)
               .WithMany(c => c.UserInfos)
               .HasForeignKey(ui => ui.CityId);

        builder.HasMany(ui => ui.FavouriteSports)
               .WithMany(fs => fs.UserInfos)
               .UsingEntity(ui => ui.ToTable("ui-fs"));
    }
}