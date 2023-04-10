using LuckyMateLuke.Examples.EfCore.Configurations.Conversions;
using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ConfigureStudentBase();
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasQueryFilter(q => q.IsActive);
        
        builder
            .Property(e => e.Grades)
            .ApplyStringConversion();
        builder
            .HasMany(e => e.Parents)
            .WithMany(e => e.Children)
            .UsingEntity<ParentStudent>();
        
        builder
            .HasOne(e => e.School)
            .WithMany(e => e.Students)
            .HasForeignKey(e => e.StudentId);
    }
}