using Feedback.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Feedback.Server.Database;

public class FeedbackContext : DbContext
{
    public const string ConnectionStringName = "MariaDb";

    public FeedbackContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<UserAccount> UserAccounts { get; set; }

    public DbSet<UserAccountRole> UserAccountRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}