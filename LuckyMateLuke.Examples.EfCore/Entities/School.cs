namespace LuckyMateLuke.Examples.EfCore.Entities;

public class School : BaseEntity
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
    
    public List<Student> Groups { get; set; }
}