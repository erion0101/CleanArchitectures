using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace q.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var contex = new ValidationContext(request);
            var failuers = _validators
                .Select(x => x.Validate((TRequest)contex.ObjectInstance))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();
            if (failuers.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var failure in failuers)
                {
                    sb.AppendLine(failure.ErrorMessage);
                }
                string errorMessages = sb.ToString();

                if (!string.IsNullOrEmpty(errorMessages))
                {
                    throw new System.ComponentModel.DataAnnotations.ValidationException(errorMessages);
                }
            }


            return next();
        }
    }
}
