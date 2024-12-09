using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Entites;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.CreateDistrict;

public class CreateDistrictCommandHandler(IDistrictRepo districtRepo, IGMapper mapper)
    : IRequestHandler<CreateDistrictCommand, Result<DistrictResponseDto>>
{
    private readonly IDistrictRepo _districtRepo = districtRepo;
    private readonly IGMapper _mapper = mapper;

    public async Task<Result<DistrictResponseDto>> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
    {
        var district = _mapper.Map<District>(request.DistrictRequestDto);
        try
        {
            await _districtRepo.Create(district);
        }
        catch (Exception ex)
        {
            return Result<DistrictResponseDto>.CreateException(ex);
        }
        var districtResponseDto = _mapper.Map<DistrictResponseDto>(district);

        return Result<DistrictResponseDto>.Success(districtResponseDto, HttpStatusCode.Created);
    }
}