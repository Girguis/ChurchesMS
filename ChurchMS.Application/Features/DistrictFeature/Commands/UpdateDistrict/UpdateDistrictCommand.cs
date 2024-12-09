using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.UpdateDistrict;

public class UpdateDistrictCommand : IRequest<Result<DistrictResponseDto>>
{
    public int Id { get; set; }
    public DistrictRequestDto DistrictRequestDto { get; set; }
}