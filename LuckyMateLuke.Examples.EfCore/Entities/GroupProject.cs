namespace LuckyMateLuke.Examples.EfCore.Entities;

public class GroupProject : BaseEntity
{
    public List<Student> Students { get; set; }
}