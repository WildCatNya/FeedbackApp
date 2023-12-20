using Feedback.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

#pragma warning disable CS1030

public sealed class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable(nameof(UserAccount));

        builder.HasKey(x => x.Id);

#warning Конфигурация UserAccountEmail написанна в классе EmailConfiguration

        builder.Navigation(x => x.UserAccountRoles).AutoInclude();
    }
}