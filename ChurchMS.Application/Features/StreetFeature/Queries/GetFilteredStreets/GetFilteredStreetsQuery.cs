using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Common.Response;
using MediatR;

namespace ChurchMS.Application.Features.StreetFeature.Queries.GetFilteredStreets;

public class GetFilteredStreetsQuery : IRequest<Result<PagedResult<StreetResponseDto>>>
{
    public QueryDto QueryDto { get; set; }
}