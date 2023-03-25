using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class School : BaseEntity.BaseEntity
{
    public School(DefaultInformation stdInfo)
        : base(stdInfo)
    {
    }

    private School()
    {
    }

    public string Name { get; set; }
    
    public string State { get; set; }
    
    public string City { get; set; }

    public List<Student> Students { get; set; }
    
    public List<Group> Groups { get; set; }
}