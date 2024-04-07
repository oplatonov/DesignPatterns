using System.Data.Common;
using DesignPatterns.App.Abstractions.Persistence;
using DesignPatterns.Infrastructure.Persistence.DbConnections;
using DesignPatterns.Infrastructure.Persistence.DbConnections.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;

namespace DesignPatterns.Infrastructure;

public static class DependencyInjection
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
	{
		services.AddPersistence(config);
	}
	
	private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<NpgConnectionOptions>(configuration.GetSection(NpgConnectionOptions.Section));
		
		DbProviderFactories.RegisterFactory(ProviderName.Npgsql, NpgsqlFactory.Instance);
		
		services.AddScoped<IDbConnectionFactory, DbConnectionFactory>(provider =>
			new DbConnectionFactory(provider.GetService<IOptions<NpgConnectionOptions>>()));
	}
}