using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Commands.DeleteCity;

public class DeleteCityCommand : IRequest<Result<CityResponseDto>>
{
    public int Id { get; set; }
}