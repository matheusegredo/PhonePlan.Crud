using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Crud.Api.Pipelines
{
	public class ValidatorPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly IValidator<TRequest> _validator;

		public ValidatorPipeline(IValidator<TRequest> validator)
		{
			_validator = validator;
		}

		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var errors = _validator.Validate(request).Errors;

			if (errors.Any())
				throw new ValidationException(errors);

			return next();
		}
	}
}
