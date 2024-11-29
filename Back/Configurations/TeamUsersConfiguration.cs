using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class TeamUsersConfiguration : IEntityTypeConfiguration<TeamUsers>
{
    public void Configure(EntityTypeBuilder<TeamUsers> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasMany(tu => tu.Users)
               .WithMany(u => u.TeamsUsers)
               .UsingEntity(tu => tu.ToTable("tu-u"));

        builder.HasOne(tu => tu.Team)
               .WithOne(t => t.TeamUsers)
               .HasForeignKey<TeamUsers>(tu => tu.TeamId);

        builder.HasOne(tu => tu.Role)
               .WithMany(r => r.TeamsUsers)
               .HasForeignKey(tu => tu.RoleId);
    }
}