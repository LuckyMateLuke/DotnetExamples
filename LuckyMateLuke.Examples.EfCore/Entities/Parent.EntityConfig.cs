using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class ParentEntityTypeConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(e => e.Children).WithOne(e => e.Parent).HasForeignKey(e => e.ParentId);
    }
}