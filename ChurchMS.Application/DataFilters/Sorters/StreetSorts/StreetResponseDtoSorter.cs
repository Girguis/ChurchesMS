using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Features.StreetFeature.Dtos;

namespace ChurchMS.Application.DataFilters.Sorters.StreetSorts;

public class StreetResponseDtoSorter : ISorter
{
    public static Func<StreetResponseDto, object> Name()
    {
        return x => x.Name;
    }

    public static Func<StreetResponseDto, object> Id()
    {
        return x => x.Id;
    }
}
