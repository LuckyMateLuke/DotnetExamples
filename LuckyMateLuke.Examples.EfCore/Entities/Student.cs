using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

namespace LuckyMateLuke.Examples.EfCore.Entities;

public class Student : StudentBase
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public bool IsActive { get; set; }
    
    public List<int> Grades { get; set; }

    public Group Group { get; set; }
    
    public School School { get; set; }
    
    // Direct many to many mapping 
    public List<GroupProject> GroupProjects { get; set; }
    
    // Indirect many-to-many mapping
    public List<ParentStudent> Parents { get; set; }
}