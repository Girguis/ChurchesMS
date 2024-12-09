using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Commands.CreateCity;

public class CreateCityCommand : IRequest<Result<CityResponseDto>>
{
    public CityRequestDto CityRequestDto { get; set; }
}