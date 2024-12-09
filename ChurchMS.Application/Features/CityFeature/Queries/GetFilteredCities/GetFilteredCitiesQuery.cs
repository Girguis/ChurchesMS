using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Common.Response;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetFilteredCities;

public class GetFilteredCitiesQuery : IRequest<Result<PagedResult<CityResponseDto>>>
{
    public QueryDto QueryDto { get; set; }
}