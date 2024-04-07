using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.App;

public static class DependencyInjection
{
	public static void AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(options =>
		{
			options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
		});
	}
}