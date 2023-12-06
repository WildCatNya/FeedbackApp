using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class UserAccountRoleConfiguration : IEntityTypeConfiguration<UserAccountRole>
{
    public void Configure(EntityTypeBuilder<UserAccountRole> builder)
    {
        builder.ToTable(nameof(UserAccountRole));

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Role).WithMany(x => x.UserAccountRoles).HasForeignKey(x => x.IdRole);
        builder.HasOne(x => x.UserAccount).WithMany(x => x.UserAccountRoles).HasForeignKey(x => x.IdUserAccount);

        builder.Navigation(x => x.Role).AutoInclude();

        builder.HasData(CsvToEntity.GetEntitiesFromCsv<UserAccountRole>(@"C:\FeedbackDev_table_UserAccountRole.csv"));
    }
}