using FluentValidation;
using MediatR;

namespace Application.Helpers.Pipeline
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorMessage =
                String.Join(";\n",
                    _validators
                    .Select(x => x.Validate(context))
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null)
                    .GroupBy(x => x.PropertyName,
                          x => x.ErrorMessage,
                         (propertyName, errorMessages) => new
                         {
                             Key = propertyName,
                             Values = errorMessages.Distinct().ToArray()
                         })
                    .Select(x => $"\" {x.Key} \": \"{String.Join(",", x.Values)} \""));


            if (!String.IsNullOrEmpty(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }

            return await next();
        }
    }
}
