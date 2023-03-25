namespace LuckyMateLuke.Examples.EfCore.Entities;

public class ParentStudent
{
    public int ParentId { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; }

    public Parent Parent { get; set;  }
}