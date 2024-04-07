using System.Data;
using System.Data.Common;
using DesignPatterns.App.Abstractions.Persistence;
using DesignPatterns.Infrastructure.Persistence.DbConnections.Options;
using Microsoft.Extensions.Options;

namespace DesignPatterns.Infrastructure.Persistence.DbConnections;

public sealed class DbConnectionFactory : IDbConnectionFactory
{
	private readonly DbDataSource _dataSource;

	internal DbConnectionFactory(IOptions<NpgConnectionOptions>? options)
	{
		ArgumentNullException.ThrowIfNull(options);

		_dataSource = GetDataSource(options.Value.ProviderName, options.Value.ConnectionString);
	}

	public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken)
	{
		var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
		return connection;
	}
	
	private static DbDataSource GetDataSource(string? providerName, string? connectionString)
	{
		return DbProviderFactories
			       .GetFactory(providerName ?? throw new ArgumentNullException(providerName))
			       .CreateDataSource(connectionString ?? throw new ArgumentNullException(connectionString)) ??
		       throw new DataException($"Can't create data source object. Provider name: {providerName}");
	}
}