using FluentValidation;
using MediatR;

namespace Mini_Blockchain.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (failures.Any())
            throw new FluentValidation.ValidationException(failures);

        return await next();
    }
}