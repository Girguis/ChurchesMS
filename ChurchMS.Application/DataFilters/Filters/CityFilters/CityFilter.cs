using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Entites;
using System.Linq.Expressions;

namespace ChurchMS.Application.DataFilters.Filters.CityFilters;

public class CityFilter : IFilter
{
    #region Name Prop
    public static Expression<Func<City, bool>> NameStartsWith(object searchValue)
        => x => x.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<City, bool>> NameEndsWith(object searchValue)
        => x => x.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<City, bool>> NameContains(object searchValue)
        => x => x.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<City, bool>> NameEquals(object searchValue)
        => x => x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<City, bool>> NameNotEquals(object searchValue)
        => x => !x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion
}