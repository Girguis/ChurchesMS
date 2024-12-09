using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Entites;

namespace ChurchMS.Application.DataFilters.Sorters.StreetSorts;

public class StreetSorter : ISorter
{
    public static Func<Street, object> Name()
    {
        return x => x.Name;
    }

    public static Func<Street, object> Id()
    {
        return x => x.Id;
    }

    public static Func<Street, object> CreatedAt()
    {
        return x => x.CreatedAt;
    }
}