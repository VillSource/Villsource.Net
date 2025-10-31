using Villsource.Mediator.Abstractions;

namespace Villsource.Mediator;

public interface ISender
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>;
    Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest;
    Task<object?> Send(object request, CancellationToken cancellationToken = default);
}