using DesignPatterns.Common.CheckConnection;
using MediatR;

namespace DesignPatterns.App.UseCases.FactoryPattern.Queries.CheckConnection;

public sealed class CheckConnectionQuery : IRequest<CheckConnectionResponse>;