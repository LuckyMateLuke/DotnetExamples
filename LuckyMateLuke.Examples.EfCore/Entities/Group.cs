using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class Group : GroupBase
{
    public string Name { get; set; }

    public School School { get; set; }

    public List<Student> Student { get; set; }
}