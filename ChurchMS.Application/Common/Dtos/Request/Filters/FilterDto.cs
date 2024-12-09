using ChurchMS.Application.Enums;

namespace ChurchMS.Application.Common.Dtos.Request.Filters;

public class FilterDto
{
    public string PropertyName { get; set; }
    public OperatorFilter op { get; set; }
    public object Value { get; set; }
}