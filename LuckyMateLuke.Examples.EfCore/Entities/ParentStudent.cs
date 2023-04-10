namespace LuckyMateLuke.Examples.EfCore.Entities;

public class ParentStudent
{
    public ParentStudent(int parentId, int studentId)
    {
        ParentId = parentId;
        StudentId = studentId;
    }
    
    // empty for ef core
    private ParentStudent()
    {
    }
    
    public int ParentId { get; set; }

    public int StudentId { get; set; }
}