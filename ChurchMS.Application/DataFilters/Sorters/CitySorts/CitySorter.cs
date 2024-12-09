using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Entites;

namespace ChurchMS.Application.DataFilters.Sorters.CitySorts;

public class CitySorter : ISorter
{
    public static Func<City, object> Name()
    {
        return x => x.Name;
    }

    public static Func<City, object> Id()
    {
        return x => x.Id;
    }

    public static Func<City, object> CreatedAt()
    {
        return x => x.CreatedAt;
    }
}