using ChurchMS.Application.Common.Dtos.Request.Filters;
using FluentValidation;

namespace ChurchMS.Application.Features.Shared.Validators;

public class QueryDtoValidator : AbstractValidator<QueryDto>
{
    public QueryDtoValidator()
    {
        RuleForEach(x => x.Filters)
            .SetValidator(new FilterDtoValidator());

        RuleFor(x => x.Pagination)
            .SetValidator(new PaginationDtoValidator());

        RuleFor(x => x.Sort)
            .SetValidator(new SortDtoValidator());
    }
}

public class FilterDtoValidator : AbstractValidator<FilterDto>
{
    public FilterDtoValidator()
    {
        RuleFor(x => x.PropertyName)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.op)
            .IsInEnum();
    }
}

public class PaginationDtoValidator : AbstractValidator<PaginationDto>
{
    public PaginationDtoValidator()
    {
        RuleFor(x => x.PageNumber)
            .Must(x => x == null || x > 0);

        RuleFor(x => x.PageSize)
            .Must(x => x == null || x > 0);
    }
}

public class SortDtoValidator : AbstractValidator<SortDto>
{
    public SortDtoValidator()
    {
        RuleFor(x => x.PropertyName)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.SortDirection)
            .IsInEnum();
    }
}