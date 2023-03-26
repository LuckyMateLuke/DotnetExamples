using System.Linq.Expressions;
using LuckyMateLuke.Examples.EfCore.Entities;
using LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

namespace LuckyMateLuke.Examples.EfCore.ExtensionMethods;

public static class Filters
{
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> query,
        Expression<Func<T, bool>> predicate,
        bool condition)
    { 
        return condition
            ? query.Where(predicate)
            : query;
    }
    
    public static IQueryable<T> OrderByIdDescending<T>(this IQueryable<T> query) 
        where T : BaseEntity
    {
        return query.OrderByDescending(x => x.Id);
    }
    
    public static IQueryable<T> OrderById<T>(this IQueryable<T> query) 
        where T : BaseEntity
    {
        return query.OrderBy(x => x.Id);
    }

    public static IQueryable<T> FilterBySchool<T>(this IQueryable<T> query, DefaultIds ids) 
        where T : BaseEntity
    {
        return query.Where(x => x.SchoolId == ids.schoolId);
    }

    public static IQueryable<T> FilterByGroup<T>(this IQueryable<T> query, DefaultIds ids)  
        where T : GroupBase
    {
        return query.Where(x => x.GroupId == ids.groupId);
    }
    
    public static IQueryable<T> FilterByStudent<T>(this IQueryable<T> query, DefaultIds ids) 
        where T : Student
    {
        return query.Where(x => x.MetaData.CreatedBy == ids.userId);
    }
}