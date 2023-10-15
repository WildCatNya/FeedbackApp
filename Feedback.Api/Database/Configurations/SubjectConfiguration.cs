using Feedback.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Api.Database.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable(nameof(Subject));

        builder.HasKey(t => t.Id);

        builder.Property(x => x.Value).HasMaxLength(100);

        builder.Property(x => x.Hide).HasDefaultValue(false);
    }
}