namespace DesignPatterns.Infrastructure.Persistence.DbConnections.Options;

public abstract class DbConnectionOptionsBase
{
	public string? ProviderName { get; init; }
	public string? ConnectionString { get; init; }
}