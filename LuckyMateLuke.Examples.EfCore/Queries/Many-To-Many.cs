using LuckyMateLuke.Examples.EfCore.Configurations.Conversions;
using LuckyMateLuke.Examples.EfCore.Entities;
using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using LuckyMateLuke.Examples.EfCore.ExtensionMethods;
using LuckyMateLuke.Examples.EfCore.Projections;
using Microsoft.EntityFrameworkCore;

namespace LuckyMateLuke.Examples.EfCore.Queries;

// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq
public class ManyToMany
{
    private readonly CustomDbContext _dbContext;

    public ManyToMany(CustomDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Student>> AllStudentsWithParents()
    {
        var students = _dbContext
            .Student
            .Include(x => x.Parents);

        return await students.ToListAsync();
    }
    
    // if you'd like using the query syntax a extra join entity property should be added 
    // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#many-to-many-with-navigations-to-and-from-join-entity
    public async Task<List<Student>> AllStudentsWithOrWithoutParents() // Left join
    {
        var students = _dbContext
            .Student
            .Include(x => x.Parents)
            .DefaultIfEmpty();

        return await students.ToListAsync();
    }
    
    public async Task PairStudentWithParent()
    {
        var pairing = new ParentStudent(1, 12);
        
        _dbContext.Add(pairing);
        await _dbContext.SaveChangesAsync();
    }
}