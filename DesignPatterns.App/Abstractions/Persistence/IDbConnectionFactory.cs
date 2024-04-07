using System.Data;

namespace DesignPatterns.App.Abstractions.Persistence;

public interface IDbConnectionFactory
{
	Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken);
}