using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.DistrictFeature.Queries.GetDistrict;

public class GetDistrictQuery : IRequest<Result<DistrictResponseDto>>
{
    public int Id { get; set; }
}
