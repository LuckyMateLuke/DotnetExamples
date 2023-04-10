﻿using LuckyMateLuke.Examples.EfCore.Configurations.Conversions;
using LuckyMateLuke.Examples.EfCore.Entities;
using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using LuckyMateLuke.Examples.EfCore.ExtensionMethods;
using LuckyMateLuke.Examples.EfCore.Projections;
using Microsoft.EntityFrameworkCore;

namespace LuckyMateLuke.Examples.EfCore.Queries;

// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq

public class DefaultQueries
{
    private readonly CustomDbContext _dbContext;

    public DefaultQueries(CustomDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<StudentIdWithName>> SimpleQueryWithHandyExtensions(DefaultIds ids, string nameFilter, bool? isActiveFilter)
    {
        // method syntax
        var query = _dbContext
            .Student
            .FilterByGroup(ids)
            .WhereIf(q => q.Name.Contains(nameFilter), !string.IsNullOrWhiteSpace(nameFilter))
            .WhereIf(q => q.IsActive == isActiveFilter, isActiveFilter.HasValue)
            .OrderById()
            .Select(StudentIdWithName.Projection);
        
        return await query
            .TagWithCallSite()
            .ToListAsync();
    }
    
    // if you'd like using the query syntax a extra join entity property should be added 
    // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#many-to-many-with-navigations-to-and-from-join-entity
    public async Task<List<Student>> GetStudentsWithoutParents() // Left join
    {
        var allStudents = _dbContext
            .Student
            .Include(x => x.Parents)
            .DefaultIfEmpty();

        return await allStudents
            .TagWithCallSite()
            .ToListAsync();
    }
    
    public async Task PairStudentWithParent()
    {
        var pairing = new ParentStudent(1, 12);
        
        _dbContext.Add(pairing);
        await _dbContext.SaveChangesAsync();
    }
}