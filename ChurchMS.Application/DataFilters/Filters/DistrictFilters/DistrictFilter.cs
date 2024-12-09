using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Entites;
using System.Linq.Expressions;

namespace ChurchMS.Application.DataFilters.Filters.DistrictFilters;

public class DistrictFilter : IFilter
{
    #region Name Prop
    public static Expression<Func<District, bool>> NameStartsWith(object searchValue)
        => x => x.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> NameEndsWith(object searchValue)
        => x => x.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> NameContains(object searchValue)
        => x => x.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> NameEquals(object searchValue)
        => x => x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion

    #region City Name Prop
    public static Expression<Func<District, bool>> CityNameStartsWith(object searchValue)
        => x => x.City.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> CityNameEndsWith(object searchValue)
        => x => x.City.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> CityNameContains(object searchValue)
        => x => x.City.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> CityNameEquals(object searchValue)
        => x => x.City.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<District, bool>> CityNameNotEquals(object searchValue)
        => x => !x.City.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion
}