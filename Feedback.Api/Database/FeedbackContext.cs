using Feedback.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Feedback.Api.Database;

public sealed class FeedbackContext : DbContext
{
    public FeedbackContext(DbContextOptions options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<ResultTable> Results { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserToken> UserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}