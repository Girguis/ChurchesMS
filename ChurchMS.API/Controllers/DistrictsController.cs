using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Features.DistrictFeature.Commands.CreateDistrict;
using ChurchMS.Application.Features.DistrictFeature.Commands.DeleteDistrict;
using ChurchMS.Application.Features.DistrictFeature.Commands.UpdateDistrict;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Features.DistrictFeature.Queries.GetDistrict;
using ChurchMS.Application.Features.DistrictFeature.Queries.GetFilteredDistricts;
using ChurchMS.Domain.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchMS.API.Controllers;

public class DistrictsController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(PagedResult<DistrictResponseDto>))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.GetDistrict)]
    public async Task<IActionResult> Get([FromQuery] QueryDto queryDto)
    {
        var result = await _mediator.Send(new GetFilteredDistrictsQuery
        {
            QueryDto = queryDto
        });

        return result.ToActionResult();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(DistrictResponseDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.GetDistrict)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetDistrictQuery()
        {
            Id = id
        });

        return result.ToActionResult();
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(DistrictResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.CreateDistrict)]
    public async Task<IActionResult> Create(DistrictRequestDto districtRequestDto)
    {
        var result = await _mediator.Send(new CreateDistrictCommand()
        {
            DistrictRequestDto = districtRequestDto
        });

        return result.ToActionResult();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200, Type = typeof(DistrictResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.UpdateDistrict)]
    public async Task<IActionResult> Update(int id, DistrictRequestDto districtRequestDto)
    {
        var result = await _mediator.Send(new UpdateDistrictCommand()
        {
            Id = id,
            DistrictRequestDto = districtRequestDto
        });

        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200, Type = typeof(DistrictResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.DeleteDistrict)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteDistrictCommand()
        {
            Id = id
        });

        return result.ToActionResult();
    }
}