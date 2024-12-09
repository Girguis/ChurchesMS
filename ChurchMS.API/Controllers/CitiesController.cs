using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Features.CityFeature.Commands.CreateCity;
using ChurchMS.Application.Features.CityFeature.Commands.DeleteCity;
using ChurchMS.Application.Features.CityFeature.Commands.UpdateCity;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Features.CityFeature.Queries.GetCity;
using ChurchMS.Application.Features.CityFeature.Queries.GetFilteredCities;
using ChurchMS.Domain.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchMS.API.Controllers;

public class CitiesController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(PagedResult<CityResponseDto>))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.GetCity)]
    public async Task<IActionResult> Get([FromQuery] QueryDto queryDto)
    {
        var result = await _mediator.Send(new GetFilteredCitiesQuery
        {
            QueryDto = queryDto
        });

        return result.ToActionResult();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(CityResponseDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.GetCity)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCityQuery()
        {
            Id = id
        });

        return result.ToActionResult();
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(CityResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.CreateCity)]
    public async Task<IActionResult> Create(CityRequestDto cityRequestDto)
    {
        var result = await _mediator.Send(new CreateCityCommand()
        {
            CityRequestDto = cityRequestDto
        });

        return result.ToActionResult();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200, Type = typeof(CityResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.UpdateCity)]
    public async Task<IActionResult> Update(int id, CityRequestDto cityRequestDto)
    {
        var result = await _mediator.Send(new UpdateCityCommand()
        {
            Id = id,
            CityRequestDto = cityRequestDto
        });

        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200, Type = typeof(CityResponseDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.DeleteCity)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCityCommand()
        {
            Id = id
        });

        return result.ToActionResult();
    }
}