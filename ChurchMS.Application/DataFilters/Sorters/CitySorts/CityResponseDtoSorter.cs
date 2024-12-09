using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Features.CityFeature.Dtos;

namespace ChurchMS.Application.DataFilters.Sorters.CitySorts;

public class CityResponseDtoSorter : ISorter
{
    public static Func<CityResponseDto, object> Name()
    {
        return x => x.Name;
    }

    public static Func<CityResponseDto, object> Id()
    {
        return x => x.Id;
    }
}
