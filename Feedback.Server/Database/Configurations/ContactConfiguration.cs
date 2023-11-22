using Feedback.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable(nameof(Role));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StudentGroup).HasMaxLength(15);
        builder.Property(x => x.Telephone).HasMaxLength(30);
        builder.Property(x => x.Message).HasMaxLength(1000);

        builder.HasOne(x => x.Subject).WithMany(x => x.Contacts).HasForeignKey(x => x.IdSubject);
        builder.HasOne(x => x.Topic).WithMany(x => x.Contacts).HasForeignKey(x => x.IdTopic);
    }
}