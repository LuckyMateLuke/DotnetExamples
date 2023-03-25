﻿namespace LuckyMateLuke.Examples.EfCore.Entities;

public class Parent : BaseEntity.BaseEntity
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public List<ParentStudent> Children { get; set; }
}