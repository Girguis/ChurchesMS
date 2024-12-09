using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.StreetFeature.Commands.CreateStreet;

public class CreateStreetCommand : IRequest<Result<StreetResponseDto>>
{
    public StreetRequestDto StreetRequestDto { get; set; }
}