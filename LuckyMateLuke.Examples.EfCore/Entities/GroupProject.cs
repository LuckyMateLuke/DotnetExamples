using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class GroupProject : GroupBase
{
    public int Score { get; set; }
    
    public List<Student> Students { get; set; }
}