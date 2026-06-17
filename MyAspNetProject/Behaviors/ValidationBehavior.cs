using FluentValidation;
using MediatR;

namespace MyAspNetProject.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults =
                await Task.WhenAll(
                    validators.Select(v =>
                        v.ValidateAsync(
                            context,
                            cancellationToken)));

            var failures =
                validationResults
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null)
                    .ToList();

            if (failures.Any())
                throw new ValidationException(failures);
        }

        return await next();
    }
}