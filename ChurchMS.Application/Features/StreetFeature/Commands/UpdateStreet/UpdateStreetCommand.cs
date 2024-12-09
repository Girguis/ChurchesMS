using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.StreetFeature.Commands.UpdateStreet;

public class UpdateStreetCommand : IRequest<Result<StreetResponseDto>>
{
    public int Id { get; set; }
    public StreetRequestDto StreetRequestDto { get; set; }
}