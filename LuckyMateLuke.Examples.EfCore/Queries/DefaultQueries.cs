using LuckyMateLuke.Examples.EfCore.Entities;
using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;
using LuckyMateLuke.Examples.EfCore.ExtensionMethods;
using LuckyMateLuke.Examples.EfCore.Projections;
using Microsoft.EntityFrameworkCore;

namespace LuckyMateLuke.Examples.EfCore.Queries;

public class DefaultQueries
{
    private readonly CustomDbContext _dbContext;

    public DefaultQueries(CustomDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<StudentIdWithName>> SimpleQueryWithHandyExtensions(DefaultIds ids, string nameFilter, bool? isActiveFilter)
    {
        var query = _dbContext
            .Student
            .TagWithCallSite()
            .FilterByGroup(ids)
            .WhereIf(q => q.Name.Contains(nameFilter), !string.IsNullOrWhiteSpace(nameFilter))
            .WhereIf(q => q.IsActive == isActiveFilter, isActiveFilter.HasValue)
            .OrderById()
            .Select(StudentIdWithName.Projection);

        return await query.ToListAsync();
    }
}