using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

internal class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ConfigureGroupBase();

        builder.HasOne(e => e.School).WithMany(e => e.Groups).HasForeignKey(e => e.SchoolId);
    }
}