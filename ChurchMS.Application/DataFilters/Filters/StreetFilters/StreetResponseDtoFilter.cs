using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using System.Linq.Expressions;

namespace ChurchMS.Application.DataFilters.Filters.StreetFilters;

public class StreetResponseDtoFilter : IFilter
{
    #region Name Prop
    public static Expression<Func<StreetResponseDto, bool>> NameStartsWith(object searchValue)
        => x => x.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> NameEndsWith(object searchValue)
        => x => x.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> NameContains(object searchValue)
        => x => x.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> NameEquals(object searchValue)
        => x => x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> NameNotEquals(object searchValue)
        => x => !x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion

    #region District Name Prop
    public static Expression<Func<StreetResponseDto, bool>> DistrictNameStartsWith(object searchValue)
        => x => x.District.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> DistrictNameEndsWith(object searchValue)
        => x => x.District.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> DistrictNameContains(object searchValue)
        => x => x.District.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> DistrictNameEquals(object searchValue)
        => x => x.District.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<StreetResponseDto, bool>> DistrictNameNotEquals(object searchValue)
        => x => !x.District.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion
}