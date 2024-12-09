using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Entites;
using System.Linq.Expressions;

namespace ChurchMS.Application.DataFilters.Filters.StreetFilters;

public class StreetFilter : IFilter
{
    #region Name Prop
    public static Expression<Func<Street, bool>> NameStartsWith(object searchValue)
        => x => x.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> NameEndsWith(object searchValue)
        => x => x.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> NameContains(object searchValue)
        => x => x.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> NameEquals(object searchValue)
        => x => x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> NameNotEquals(object searchValue)
        => x => !x.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion

    #region District Name Prop
    public static Expression<Func<Street, bool>> DistrictNameStartsWith(object searchValue)
        => x => x.District.Name.StartsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> DistrictNameEndsWith(object searchValue)
        => x => x.District.Name.EndsWith(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> DistrictNameContains(object searchValue)
        => x => x.District.Name.Contains(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> DistrictNameEquals(object searchValue)
        => x => x.District.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);

    public static Expression<Func<Street, bool>> DistrictNameNotEquals(object searchValue)
        => x => !x.District.Name.Equals(searchValue.ToString(), StringComparison.OrdinalIgnoreCase);
    #endregion
}