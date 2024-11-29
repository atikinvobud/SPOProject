using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.TeamUsers)
               .WithMany(tu => tu.Requests)
               .HasForeignKey(r => r.TeamUsersId);

        builder.HasOne(r => r.Status)
               .WithMany(s => s.Requests)
               .HasForeignKey(r => r.StatusId);

        builder.HasOne(r => r.Tournament)
               .WithMany(t => t.Requests)
               .HasForeignKey(r => r.TournamentId);
    }
}