using Villsource.Mediator.Abstractions;
using Villsource.Result;

namespace Villsource.Mediator;

public interface IMediator
{
    Task<Result<TResponse>> Send<TRequest, TResponse>
    (
        IRequest<TRequest, TResponse> request,
        CancellationToken cancellationToken = default
    ) where TRequest : class, IRequest<TRequest, TResponse>;
}