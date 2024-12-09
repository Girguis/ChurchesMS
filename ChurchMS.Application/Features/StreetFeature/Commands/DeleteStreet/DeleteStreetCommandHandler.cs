using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.StreetFeature.Commands.DeleteStreet;

public class DeleteStreetCommandHandler(IStreetRepo streetRepo, IGMapper mapper)
    : IRequestHandler<DeleteStreetCommand, Result<StreetResponseDto>>
{
    private readonly IStreetRepo _streetRepo = streetRepo;
    private readonly IGMapper _mapper = mapper;

    public async Task<Result<StreetResponseDto>> Handle(DeleteStreetCommand request, CancellationToken cancellationToken)
    {
        var street = await _streetRepo.Get(request.Id);
        if (street == null)
            return Result<StreetResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.Street);

        try
        {
            await _streetRepo.Delete(street);
        }
        catch (Exception ex)
        {
            return Result<StreetResponseDto>.CreateException(ex);
        }
        var streetResponseDto = _mapper.Map<StreetResponseDto>(street);

        return Result<StreetResponseDto>.Success(streetResponseDto, HttpStatusCode.Created);
    }
}