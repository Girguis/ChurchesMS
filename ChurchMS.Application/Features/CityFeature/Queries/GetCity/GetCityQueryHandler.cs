using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetCity;

internal class GetCityQueryHandler(ICityRepo cityRepo)
    : IRequestHandler<GetCityQuery, Result<CityResponseDto>>
{
    private readonly ICityRepo _cityRepo = cityRepo;

    public async Task<Result<CityResponseDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepo
                            .GetAsNoTracking<CityResponseDto>(request.Id);
        if (city == null)
            return Result<CityResponseDto>.Failure(System.Net.HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.City);

        return Result<CityResponseDto>.Success(city);
    }
}
