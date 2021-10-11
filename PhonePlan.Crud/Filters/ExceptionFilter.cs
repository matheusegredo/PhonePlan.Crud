using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhonePlan.CrossCutting.Exceptions;
using System.Linq;

namespace PhonePlan.Crud.Api.Filters
{
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			var ex = context.Exception;

			context.Result = ex switch
			{
				ValidationException validation => PrepareBadRequestMessage(validation),
				NotFoundException notFoundException => new NotFoundObjectResult(notFoundException.Message),
				_ => new ObjectResult(string.Empty) { StatusCode = 500 }
			};
		}

		private static BadRequestObjectResult PrepareBadRequestMessage(ValidationException ex)
		{
			return new BadRequestObjectResult(new { errors = ex.Errors.Select(p => p.ErrorMessage) });
		}
	}
}
