using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Entites;

namespace ChurchMS.Application.DataFilters.Sorters.DistrictSorter;

public class DistrictSorter : ISorter
{
    public static Func<District, object> Name()
    {
        return x => x.Name;
    }

    public static Func<District, object> Id()
    {
        return x => x.Id;
    }

    public static Func<District, object> CreatedAt()
    {
        return x => x.CreatedAt;
    }

    public static Func<District, object> CityName()
    {
        return x => x.City.Name;
    }
}