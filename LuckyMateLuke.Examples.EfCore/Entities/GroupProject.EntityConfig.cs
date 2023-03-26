using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

internal class GroupProjectConfiguration : IEntityTypeConfiguration<GroupProject>
{
    public void Configure(EntityTypeBuilder<GroupProject> builder)
    {
        builder.ConfigureGroupBase();
    }
}