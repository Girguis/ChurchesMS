using ChurchMS.Application.Constants;
using ChurchMS.Application.Results;
using FluentValidation;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Extensions.MediatR;

public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var errors = _validators
                        .Select(v => v.ValidateAsync(request).GetAwaiter().GetResult())
                        .SelectMany(v => v.Errors)
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage).Distinct());

        if (errors.Count != 0)
            return CreateValidationResult<TResponse>(errors);

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Dictionary<string, IEnumerable<string>> errors)
    {
        var instance = Activator.CreateInstance(typeof(TResult), true);
        if (instance == null)
            return default;

        var method = typeof(TResult).GetMethods().FirstOrDefault(t =>
        {
            var paremeters = t.GetParameters();
            var res = t.Name.Equals(nameof(Result.Failure), StringComparison.OrdinalIgnoreCase) &&
                      paremeters.Length == 3 &&
                      paremeters[0].ParameterType == typeof(HttpStatusCode) &&
                      paremeters[1].ParameterType == typeof(string) &&
                      paremeters[2].ParameterType == typeof(object);

            return res;
        });

        if (method == null)
            return default;

        return (TResult)method.Invoke(instance, [HttpStatusCode.BadRequest, ErrorCodes.ValidationError, errors]);
    }
}