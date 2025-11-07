using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Villsource.Mediator.Abstractions;
using Villsource.Result;

namespace Villsource.Mediator;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    public Task<Result<TResponse>> Send<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default) where TRequest : class, IRequest<TRequest, TResponse>
    {
        return serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>()
            .Handle(Unsafe.As<TRequest>(request), cancellationToken);
    }
}