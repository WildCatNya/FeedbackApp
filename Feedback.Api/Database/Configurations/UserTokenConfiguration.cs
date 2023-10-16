using Feedback.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Api.Database.Configurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(nameof(UserToken));

        builder.HasKey(t => t.Id);

        builder.HasIndex(x => x.IdUser);

        builder.HasOne(x => x.IdUserNavigation).WithMany(x => x.UserTokens).HasForeignKey(x => x.IdUser);
    }
}