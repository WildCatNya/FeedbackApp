using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable(nameof(Topic));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value).HasMaxLength(50);
    }
}