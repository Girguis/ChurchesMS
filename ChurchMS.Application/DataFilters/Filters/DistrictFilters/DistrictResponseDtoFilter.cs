using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using System.Linq.Expressions;

namespace ChurchMS.Application.DataFilters.Filters.DistrictFilters;

public class DistrictResponseDtoFilter : IFilter
{
    #region Name Prop
    public static Expression<Func<DistrictResponseDto, bool>> NameStartsWith(object searchValue)
        => x => x.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> NameEndsWith(object searchValue)
        => x => x.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> NameContains(object searchValue)
        => x => x.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> NameEquals(object searchValue)
        => x => x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> NameNotEquals(object searchValue)
        => x => !x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion

    #region City Name Prop
    public static Expression<Func<DistrictResponseDto, bool>> CityNameStartsWith(object searchValue)
        => x => x.City.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> CityNameEndsWith(object searchValue)
        => x => x.City.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> CityNameContains(object searchValue)
        => x => x.City.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> CityNameEquals(object searchValue)
        => x => x.City.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<DistrictResponseDto, bool>> CityNameNotEquals(object searchValue)
        => x => !x.City.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion
}