using FluentValidation;

namespace ChurchMS.Application.Features.CityFeature.Commands.CreateCity;

internal class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(x => x.CityRequestDto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);
    }
}