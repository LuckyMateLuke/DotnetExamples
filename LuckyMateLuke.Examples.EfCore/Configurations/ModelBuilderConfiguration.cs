using LuckyMateLuke.Examples.EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LuckyMateLuke.Examples.EfCore.Configurations;

public static class ModelBuilderConfiguration
{
    public static ModelBuilder ConfigureModels(this ModelBuilder modelBuilder)
    {
        // Should be done explicitly, could be done with:
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly)
        modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GroupProjectConfiguration());
        modelBuilder.ApplyConfiguration(new ParentConfiguration());
        modelBuilder.ApplyConfiguration(new SchoolConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        return modelBuilder;
    }
}