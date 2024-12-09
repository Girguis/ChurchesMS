using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.StreetFeature.Commands.UpdateStreet;

public class UpdateStreetCommandHandler(IStreetRepo streetRepo, IGMapper mapper)
    : IRequestHandler<UpdateStreetCommand, Result<StreetResponseDto>>
{
    public async Task<Result<StreetResponseDto>> Handle(UpdateStreetCommand request, CancellationToken cancellationToken)
    {
        var street = await streetRepo.Get(request.Id);
        if (street == null)
            return Result<StreetResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.Street);

        mapper.Map((request.Id, request.StreetRequestDto), street);
        try
        {
            await streetRepo.Update(street);
            var streetResponseDto = mapper.Map<StreetResponseDto>(street);

            return Result<StreetResponseDto>.Success(streetResponseDto, HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return Result<StreetResponseDto>.CreateException(ex);
        }
    }
}