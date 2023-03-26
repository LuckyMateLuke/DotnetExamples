using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

internal class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ConfigureBaseEntity();
        
        // builder.ToTable("School", b => b.IsTemporal()) - Temporal seems not to work quite right with metadata
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(e => e.Groups).WithOne();
        builder.HasMany(e => e.Students).WithOne();
    }
}