using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.DataFilters.Filters.DistrictFilters;
using ChurchMS.Application.DataFilters.Sorters.DistrictSorter;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Common.Response;
using MediatR;

namespace ChurchMS.Application.Features.DistrictFeature.Queries.GetFilteredDistricts;

public class GetFilteredCitiesQueryHandler(IDistrictRepo districtRepo)
    : IRequestHandler<GetFilteredDistrictsQuery, Result<PagedResult<DistrictResponseDto>>>
{
    private readonly IDistrictRepo _districtRepo = districtRepo;

    public async Task<Result<PagedResult<DistrictResponseDto>>> Handle(GetFilteredDistrictsQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtRepo
                            .GetAsNoTracking<DistrictResponseDto, DistrictResponseDtoFilter, DistrictResponseDtoSorter>(request.QueryDto);

        return Result<PagedResult<DistrictResponseDto>>.Success(data);
    }
}