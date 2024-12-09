using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.DataFilters.Filters.StreetFilters;
using ChurchMS.Application.DataFilters.Sorters.StreetSorts;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Common.Response;
using MediatR;

namespace ChurchMS.Application.Features.StreetFeature.Queries.GetFilteredStreets;

public class GetFilteredStreetsQueryHandler(IStreetRepo streetRepo)
        : IRequestHandler<GetFilteredStreetsQuery, Result<PagedResult<StreetResponseDto>>>
{
    private readonly IStreetRepo _streetRepo = streetRepo;

    public async Task<Result<PagedResult<StreetResponseDto>>> Handle(GetFilteredStreetsQuery request, CancellationToken cancellationToken)
    {
        var data = await _streetRepo
                            .GetAsNoTracking<StreetResponseDto, StreetResponseDtoFilter, StreetResponseDtoSorter>(request.QueryDto);

        return Result<PagedResult<StreetResponseDto>>.Success(data);
    }
}