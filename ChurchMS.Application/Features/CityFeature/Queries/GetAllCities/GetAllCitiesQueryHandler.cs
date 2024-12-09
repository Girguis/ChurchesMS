using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetAllCities;

public class GetAllCitiesQueryHandler(ICityRepo cityRepo)
    : IRequestHandler<GetAllCitiesQuery, Result<List<CityResponseDto>>>
{
    private readonly ICityRepo _cityRepo = cityRepo;

    public async Task<Result<List<CityResponseDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        var citiesDto = await _cityRepo
                                .GetAllAsNoTracking<CityResponseDto>();

        return Result<List<CityResponseDto>>.Success(citiesDto);
    }
}