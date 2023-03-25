using LuckyMateLuke.Examples.EfCore.Configurations;
using LuckyMateLuke.Examples.EfCore.Entities;
using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace LuckyMateLuke.Examples.EfCore;

public class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions options)
    : base(options)
    {
    }

    public DbSet<School> School { get; set; }
    
    public DbSet<Group> Group { get; set; }
    
    public DbSet<Student> Student { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        DoSomethingWithTheChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync(DefaultInformation ids, CancellationToken cancellationToken = default)
    {
        DoSomethingWithTheChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureModels();
        base.OnModelCreating(modelBuilder);
    }

    // https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew#pre-convention-model-configuration
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ConfigureBool();
        configurationBuilder.ConfigureString();
        configurationBuilder.ConfigureIntList();
        configurationBuilder.ConfigureDateTime();
        configurationBuilder.ConfigureDiscriminator();

        base.ConfigureConventions(configurationBuilder);
    }

    private static void DoSomethingWithTheChanges()
    {
        // var insertedEntries = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added)
    }
}