namespace LuckyMateLuke.Examples.EfCore.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }

    public School School { get; set; }

    public List<Student> Student { get; set; }
}