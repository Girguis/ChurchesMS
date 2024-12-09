namespace ChurchMS.Domain.Common.Response;

public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int? CurrentPage { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }

    public PagedResult(List<T> items, int? currentPage, int? pageSize, int totalCount)
    {
        Items = items;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public PagedResult(IEnumerable<T> items, int? currentPage, int? pageSize, int totalCount)
    {
        Items = items.ToList();
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public PagedResult(IQueryable<T> items, int? currentPage, int? pageSize, int totalCount)
    {
        Items = items.ToList();
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
}