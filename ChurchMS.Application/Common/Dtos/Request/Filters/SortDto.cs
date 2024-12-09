using ChurchMS.Application.Enums;

namespace ChurchMS.Application.Common.Dtos.Request.Filters;

public class SortDto
{
    public string PropertyName { get; set; } = "Id";
    public SortDirection SortDirection { get; set; } = SortDirection.Asc;
}