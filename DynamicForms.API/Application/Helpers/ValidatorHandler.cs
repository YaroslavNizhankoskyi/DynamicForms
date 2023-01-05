using FluentValidation;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public abstract class ValidatorHandler<TRequest, TResponse> : IRequestHandler<TRequest,TResponse>
            where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorHandler(IEnumerable<IValidator<TRequest>> validators)
        {
            this._validators = validators;
        }

        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var errors = RequestIsValid(request);

            if (errors == null)
            {
                return await HandleRequest(request, cancellationToken);
            }

            return HandleErrorRequest(errors);
        }

        public abstract Task<TResponse> HandleRequest(TRequest request, CancellationToken cancellationToken);
        public abstract TResponse HandleErrorRequest(string errors);

        public virtual string RequestIsValid(TRequest request)
        {
            if (!_validators.Any())
            {
                return null;
            }

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = 
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
                    .Select(x => $"\" {x.Key} \": \"{String.Join(",",x.Values)} \""));

            return errorsDictionary;
        }
    }
}
