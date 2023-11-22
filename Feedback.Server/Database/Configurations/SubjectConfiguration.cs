using Feedback.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable(nameof(Subject));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value).HasMaxLength(100);

        builder.HasOne(x => x.Role).WithMany(x => x.Subjects).HasForeignKey(x => x.IdRole);
    }
}