using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.DataFilters.Filters.CityFilters;
using ChurchMS.Application.DataFilters.Sorters.CitySorts;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Common.Response;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetFilteredCities;

public class GetFilteredCitiesQueryHandler(ICityRepo cityRepo)
    : IRequestHandler<GetFilteredCitiesQuery, Result<PagedResult<CityResponseDto>>>
{
    private readonly ICityRepo _cityRepo = cityRepo;

    public async Task<Result<PagedResult<CityResponseDto>>> Handle(GetFilteredCitiesQuery request, CancellationToken cancellationToken)
    {
        var data = await _cityRepo
                            .GetAsNoTracking<CityResponseDto, CityResponseDtoFilter, CityResponseDtoSorter>(request.QueryDto);

        return Result<PagedResult<CityResponseDto>>.Success(data);
    }
}