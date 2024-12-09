using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.DeleteDistrict;

public class DeleteDistrictCommand : IRequest<Result<DistrictResponseDto>>
{
    public int Id { get; set; }
}