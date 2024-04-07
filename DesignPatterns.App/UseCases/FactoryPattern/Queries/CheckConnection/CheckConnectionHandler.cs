using System.Data;
using DesignPatterns.App.Abstractions.Persistence;
using DesignPatterns.Common.CheckConnection;
using MediatR;

namespace DesignPatterns.App.UseCases.FactoryPattern.Queries.CheckConnection;

public sealed class CheckConnectionHandler(IDbConnectionFactory dbConnectionFactory) : IRequestHandler<CheckConnectionQuery, CheckConnectionResponse>
{
	public async Task<CheckConnectionResponse> Handle(CheckConnectionQuery request, CancellationToken cancellationToken)
	{
		var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);
		return new CheckConnectionResponse(connection.State == ConnectionState.Open);
	}
}