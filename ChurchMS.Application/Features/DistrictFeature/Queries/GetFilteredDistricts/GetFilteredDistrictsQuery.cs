using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Common.Response;
using MediatR;

namespace ChurchMS.Application.Features.DistrictFeature.Queries.GetFilteredDistricts;

public class GetFilteredDistrictsQuery : IRequest<Result<PagedResult<DistrictResponseDto>>>
{
    public QueryDto QueryDto { get; set; }
}