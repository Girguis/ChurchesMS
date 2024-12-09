using ChurchMS.Application.Features.Shared.Validators;
using FluentValidation;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetFilteredCities;

public class GetFilteredCitiesQueryValidator : AbstractValidator<GetFilteredCitiesQuery>
{
    public GetFilteredCitiesQueryValidator()
    {
        RuleFor(x => x.QueryDto)
            .SetValidator(new QueryDtoValidator());
    }
}