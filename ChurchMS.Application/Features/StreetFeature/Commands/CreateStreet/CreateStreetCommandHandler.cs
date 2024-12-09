using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Entites;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.StreetFeature.Commands.CreateStreet;

public class CreateStreetCommandHandler(IStreetRepo streetRepo, IGMapper mapper)
    : IRequestHandler<CreateStreetCommand, Result<StreetResponseDto>>
{
    private readonly IStreetRepo _streetRepo = streetRepo;
    private readonly IGMapper _mapper = mapper;

    public async Task<Result<StreetResponseDto>> Handle(CreateStreetCommand request, CancellationToken cancellationToken)
    {
        var street = _mapper.Map<Street>(request.StreetRequestDto);
        try
        {
            await _streetRepo.Create(street);
        }
        catch (Exception ex)
        {
            return Result<StreetResponseDto>.CreateException(ex);
        }
        var streetResponseDto = _mapper.Map<StreetResponseDto>(street);

        return Result<StreetResponseDto>.Success(streetResponseDto, HttpStatusCode.Created);
    }
}