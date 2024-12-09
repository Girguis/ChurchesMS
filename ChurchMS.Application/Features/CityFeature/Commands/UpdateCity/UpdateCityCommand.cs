using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Commands.UpdateCity;

public class UpdateCityCommand : IRequest<Result<CityResponseDto>>
{
    public int Id { get; set; }
    public CityRequestDto CityRequestDto { get; set; }
}