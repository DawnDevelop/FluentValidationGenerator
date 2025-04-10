using FluentValidation;
using MediatR;

using ValidationException = SampleNET7.Application.Common.Exceptions.ValidationException;
namespace SampleNET7.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	 where TRequest : notnull
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
	{
		_validators = validators;
	}

 /// <summary>
 /// Handles the validation for a given request and proceeds to the next handler if validation succeeds.
 /// </summary>
 /// <param name="request">The request instance to validate.</param>
 /// <param name="next">The delegate to execute the next handler.</param>
 /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
 /// <returns>The response from the next handler.</returns>
 /// <exception cref="ValidationException">Thrown when one or more validation failures occur.</exception>
 /// <example>
 /// var response = await handleInstance.Handle(request, nextHandler, cancellationToken);
 /// Console.WriteLine(response); // The expected response if validation passes.
 /// </example>
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if (_validators.Any())
		{
			var context = new ValidationContext<TRequest>(request);

			var validationResults = await Task.WhenAll(
				_validators.Select(v =>
					v.ValidateAsync(context, cancellationToken)));

			var failures = validationResults
				.Where(r => r.Errors.Any())
				.SelectMany(r => r.Errors)
				.ToList();

			if (failures.Any())
				throw new ValidationException(failures);
		}
		return await next();
	}
}
