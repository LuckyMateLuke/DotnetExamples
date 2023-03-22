using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class SchoolEntityTypeConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("School", b => b.IsTemporal());
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();

    }
}