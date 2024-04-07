using MediatR;

namespace DesignPatterns.App.FactoryPattern.Queries.CheckConnection;

public sealed class CheckConnectionHandler : IRequestHandler<CheckConnectionQuery, bool>
{

	public async Task<bool> Handle(CheckConnectionQuery request, CancellationToken cancellationToken)
	{
		return await Task.Run(async () =>
		{
			await Task.Delay(1000, cancellationToken);
			return true;
		}, cancellationToken);
	}
}