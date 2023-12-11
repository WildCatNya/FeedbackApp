using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable(nameof(UserAccount));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DepartmentEmail).HasMaxLength(150);

        builder.Navigation(x => x.UserAccountRoles).AutoInclude();
    }
}