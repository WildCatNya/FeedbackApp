using Feedback.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable(nameof(Email));

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.UserAccounts).WithMany(x => x.Emails).UsingEntity<UserAccountEmail>(nameof(UserAccountEmail));
    }
}