using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Enums;
using System.Linq.Expressions;

namespace ChurchMS.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Filter<TEntity, TFilter>(this IQueryable<TEntity> query, List<FilterDto> filters)
    {
        var instance = Activator.CreateInstance(typeof(TFilter));
        if (instance == null)
            return query;

        foreach (var filter in filters)
        {
            var method = typeof(TFilter).GetMethods().FirstOrDefault(t =>
            {
                var res = t.Name.Equals(string.Concat(filter.PropertyName, filter.op.ToString()), StringComparison.OrdinalIgnoreCase);
                return res;
            });

            if (method == null)
                continue;

            query = query.Where((Expression<Func<TEntity, bool>>)method.Invoke(instance, [filter.Value]));
        }

        return query;
    }

    public static IQueryable<TEntity> Sort<TEntity, TFilter>(this IQueryable<TEntity> query, SortDto sortDto)
    {
        var instance = Activator.CreateInstance(typeof(TFilter));
        if (instance == null)
            return query;

        var method = typeof(TFilter).GetMethods().FirstOrDefault(t =>
        {
            var res = t.Name.Equals(sortDto.PropertyName, StringComparison.OrdinalIgnoreCase);
            return res;
        });

        if (method == null)
            return query;

        var sortExpression = (Func<TEntity, object>)method.Invoke(instance, null);
        if (sortExpression != null)
            query = sortDto?.SortDirection == SortDirection.Asc ?
                    query.OrderBy(sortExpression).AsQueryable() :
                    query.OrderByDescending(sortExpression).AsQueryable();

        return query;
    }

    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> query, PaginationDto paginationDto, int totalCount)
    {
        if (paginationDto != null &&
            paginationDto.PageNumber.HasValue &&
            paginationDto.PageSize.HasValue)
            return query
                    .Skip((paginationDto.PageNumber.Value - 1) * paginationDto.PageSize.Value)
                    .Take(paginationDto.PageSize.Value);

        paginationDto ??= new PaginationDto();
        paginationDto.PageNumber = 1;
        paginationDto.PageSize = totalCount;

        return query;
    }
}