using System.Linq.Expressions;
using BnplV2.Modules.BaseEntities;
using BnplV2.Utils.Defaults;

namespace BnplV2.Extensions;

public static class QueryableExtension
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition,
        Expression<Func<T, bool>> predicate)
    {
        if (condition)
        {
            queryable = queryable.Where(predicate);
        }

        return queryable;
    }
    
    public static IQueryable<T> OrderAndPaginate<T>(this IQueryable<T> data, PaginationFilter filter) where T : BaseEntity
    {
        var pagedResponse = data
            .OrderByDescending(x => x.CreatedDate)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize);
        return pagedResponse;
    }
}