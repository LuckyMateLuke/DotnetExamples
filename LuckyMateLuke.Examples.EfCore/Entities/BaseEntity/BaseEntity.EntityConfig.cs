using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

internal static class ParentEntityTypeConfiguration
{
    internal static void ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder)
        where T : BaseEntity
    {
        builder.HasKey(s => s.Id);
        builder.Property(e => e.Id).IsRequired().HasColumnOrder(0);
        builder.Property(x => x.SchoolId).IsRequired().HasColumnOrder(1);

        builder.OwnsOne(e => e.MetaData);
    }
    
    internal static void ConfigureGroupBase<T>(this EntityTypeBuilder<T> builder)
        where T : GroupBase
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.GroupId).IsRequired().HasColumnOrder(2);
    }
    
    internal static void ConfigureStudentBase<T>(this EntityTypeBuilder<T> builder)
        where T : StudentBase
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.StudentId).IsRequired().HasColumnOrder(3);
    }
}