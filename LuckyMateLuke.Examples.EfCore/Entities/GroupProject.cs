namespace LuckyMateLuke.Examples.EfCore.Entities;

public class GroupProject : BaseEntity.BaseEntity
{
    public int Score { get; set; }
    
    public List<Student> Students { get; set; }
}