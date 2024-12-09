using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetCity;

public class GetCityQuery : IRequest<Result<CityResponseDto>>
{
    public int Id { get; set; }
}
