using Feedback.Server.Database.Entities;
using Feedback.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Server.Database.Configurations;

public sealed class LoginPermitConfiguration : IEntityTypeConfiguration<LoginPermit>
{
    public void Configure(EntityTypeBuilder<LoginPermit> builder)
    {
        builder.ToTable(nameof(LoginPermit));

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.UserAccount).WithMany(x => x.LoginPermits).HasForeignKey(x => x.IdUserAccount);

        builder.HasData(CsvToEntity.GetEntitiesFromCsv<LoginPermit>(@"C:\FeedbackDev_table_LoginPermit.csv"));
    }
}