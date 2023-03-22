using System.Linq.Expressions;
using LuckyMateLuke.Examples.EfCore.Entities;

namespace LuckyMateLuke.Examples.EfCore.Projections;

public class StudentIdWithName
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    internal static Expression<Func<Student, StudentIdWithName>> Projection
    {
        get
        {
            return x => new StudentIdWithName
            {
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}