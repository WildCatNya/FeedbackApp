using Feedback.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Api.Database.Configurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable(nameof(Topic));

        builder.HasKey(t => t.Id);

        builder.Property(x => x.Value).HasMaxLength(25);

        builder.Property(x => x.Hide).HasDefaultValue(false);
    }
}