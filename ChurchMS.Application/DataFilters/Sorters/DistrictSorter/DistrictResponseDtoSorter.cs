using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Features.DistrictFeature.Dtos;

namespace ChurchMS.Application.DataFilters.Sorters.DistrictSorter;

public class DistrictResponseDtoSorter : ISorter
{
    public static Func<DistrictResponseDto, object> Name()
    {
        return x => x.Name;
    }

    public static Func<DistrictResponseDto, object> Id()
    {
        return x => x.Id;
    }

    public static Func<DistrictResponseDto, object> CreatedAt()
    {
        return x => x.City.Name;
    }
}
