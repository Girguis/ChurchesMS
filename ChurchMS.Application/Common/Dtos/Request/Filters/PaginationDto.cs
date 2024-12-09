namespace ChurchMS.Application.Common.Dtos.Request.Filters;

public class PaginationDto
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 20;
}