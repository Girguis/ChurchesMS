using ChurchMS.Application.Features.Shared.Validators;
using FluentValidation;

namespace ChurchMS.Application.Features.StreetFeature.Queries.GetFilteredStreets;

public class GetFilteredStreetsQueryValidator : AbstractValidator<GetFilteredStreetsQuery>
{
    public GetFilteredStreetsQueryValidator()
    {
        RuleFor(x => x.QueryDto)
            .SetValidator(new QueryDtoValidator());
    }
}
