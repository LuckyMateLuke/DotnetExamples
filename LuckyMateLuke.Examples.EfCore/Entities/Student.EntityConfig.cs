﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasQueryFilter(q => q.IsActive);

    }
}