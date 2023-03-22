namespace LuckyMateLuke.Examples.EfCore.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public bool IsActive { get; set; }
    
    public IList<int> Grades { get; set; }

    public Group Group { get; set; }
    
    public School School { get; set; }
    
    public List<GroupProject> Projects { get; set; }
}

public class ParentStudent
{
    public int ParentId { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; }

    public Parent Parent { get; set;  }
}

public class Parent : BaseEntity
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public List<Student> Projects { get; set; }
}