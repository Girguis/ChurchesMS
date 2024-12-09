using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Features.CityFeature.Dtos;
using System.Linq.Expressions;

namespace ChurchMS.Application.DataFilters.Filters.CityFilters;

public class CityResponseDtoFilter : IFilter
{
    #region Name Prop
    public static Expression<Func<CityResponseDto, bool>> NameStartsWith(object searchValue)
        => x => x.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<CityResponseDto, bool>> NameEndsWith(object searchValue)
        => x => x.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<CityResponseDto, bool>> NameContains(object searchValue)
        => x => x.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<CityResponseDto, bool>> NameEquals(object searchValue)
        => x => x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<CityResponseDto, bool>> NameNotEquals(object searchValue)
        => x => !x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion
}