using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.CreateDistrict;

public class CreateDistrictCommand : IRequest<Result<DistrictResponseDto>>
{
    public DistrictRequestDto DistrictRequestDto { get; set; }
}