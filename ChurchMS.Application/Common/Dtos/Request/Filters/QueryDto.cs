namespace ChurchMS.Application.Common.Dtos.Request.Filters;

public class QueryDto
{
    public List<FilterDto> Filters { get; set; } = [];
    public SortDto Sort { get; set; } = new SortDto();
    public PaginationDto Pagination { get; set; } = new PaginationDto();
}