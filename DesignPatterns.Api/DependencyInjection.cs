namespace DesignPatterns;

public static class DependencyInjection
{
	public static void AddApiServices(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
	}
}