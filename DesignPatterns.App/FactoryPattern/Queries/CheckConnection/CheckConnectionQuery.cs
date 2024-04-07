using MediatR;

namespace DesignPatterns.App.FactoryPattern.Queries.CheckConnection;

public sealed class CheckConnectionQuery : IRequest<bool>;