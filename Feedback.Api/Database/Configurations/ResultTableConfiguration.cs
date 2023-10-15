using Feedback.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Api.Database.Configurations;

public class ResultTableConfiguration : IEntityTypeConfiguration<ResultTable>
{
    public void Configure(EntityTypeBuilder<ResultTable> builder)
    {
        builder.ToTable("Result");

        builder.HasKey(t => t.Id);

        builder.HasIndex(x => x.IdTopic);
        builder.HasIndex(x => x.IdSubject);

        builder.Property(x => x.Fio).HasMaxLength(125);
        builder.Property(x => x.Group).HasMaxLength(10);
        builder.Property(x => x.Telephone).HasMaxLength(15);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Text).HasMaxLength(1000);
        builder.Property(x => x.Hide).HasDefaultValue(false);

        builder.HasOne(x => x.IdTopicNavigation).WithMany(x => x.Results).HasForeignKey(x => x.IdTopic);
        builder.HasOne(x => x.IdSubjectNavigation).WithMany(x => x.Results).HasForeignKey(x => x.IdSubject);
    }
}