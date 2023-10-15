using BCrypt.Net;
using Feedback.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Api.Database.Configurations;

public class UserConfigurartion : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(t => t.Id);

        builder.Property(x => x.Login).HasMaxLength(30);

        builder.HasIndex(x => x.Login).IsUnique();

        builder.Property(x => x.PasswordHash).HasMaxLength(100);

        builder.Property(x => x.Role).HasMaxLength(40);

        builder.HasData(new User[]
        {
            new()
            {
                Id = 1,
                Login = "kudke",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("gfhjkm"),
                Role = "Admin"
            }
        });
    }
}