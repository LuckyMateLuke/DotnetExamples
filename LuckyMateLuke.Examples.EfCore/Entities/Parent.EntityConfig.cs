using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

internal class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.ConfigureBaseEntity();
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(e => e.Children)
            .WithMany(e => e.Parents)
            .UsingEntity<ParentStudent>();
    }
}