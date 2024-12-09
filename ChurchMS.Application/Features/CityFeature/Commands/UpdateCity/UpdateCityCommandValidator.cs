using FluentValidation;

namespace ChurchMS.Application.Features.CityFeature.Commands.UpdateCity;

internal class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(x => x.CityRequestDto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);
    }
}
