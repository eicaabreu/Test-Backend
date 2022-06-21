using FluentValidation;
using MediatR;
using ValidationException = TEST.Application.SeedWork.Exceptions.ValidationException;

namespace TEST.Application.SeedWork.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationTasks = _validators.Select(validator => validator.ValidateAsync(request, cancellationToken));
                var validationResults = await Task.WhenAll(validationTasks);
                var failures = validationResults.SelectMany(d => d.Errors).Where(err => err is not null);

                if (failures.Any()) throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
