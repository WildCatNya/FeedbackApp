using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable(nameof(Contact));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StudentGroup).HasMaxLength(100);
        builder.Property(x => x.Telephone).HasMaxLength(30);
        builder.Property(x => x.Message).HasMaxLength(1000);

        builder.HasOne(x => x.Subject).WithMany(x => x.Contacts).HasForeignKey(x => x.IdSubject);
        builder.HasOne(x => x.Topic).WithMany(x => x.Contacts).HasForeignKey(x => x.IdTopic);

        builder.Navigation(x => x.Subject).AutoInclude();
        builder.Navigation(x => x.Topic).AutoInclude();
    }
}