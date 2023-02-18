using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SampleNET7.Application.Common.Behaviours;
using System.Reflection;

namespace SampleNET7.Application;

public static class ConfigureServices
{

	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(typeof(ConfigureServices).Assembly);
		services.AddMediatR(c =>
			c.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		
		return services;
	}


}