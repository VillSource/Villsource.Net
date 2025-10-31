using System;
using Microsoft.Extensions.DependencyInjection;
using Villsource.Mediator.Abstractions;

namespace Villsource.Mediator.Handlers;

public class Sender(IServiceProvider serviceProvider) : ISender
{
    public Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>
    {
        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
        return handler.Handle(request, cancellationToken);
    }

    public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
    {
        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();
        return handler.Handle(request, cancellationToken);
    }

    public Task<object?> Send(object request, CancellationToken cancellationToken = default)
    {
        // var interfaces = request.GetType().GetInterfaces();
        // var requestWithResponseType = interfaces.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>));
        // if (requestWithResponseType is null)
        // {
        //     var x=interfaces.FirstOrDefault(i =>  i.GetGenericTypeDefinition() == typeof(IRequest));
        //     return Task.FromResult<object?>(x);
        // };
        // var responseType = requestWithResponseType.GetGenericArguments()[0];
        //
        // var handler = _serviceProvider.GetRequiredKeyedService<object>(typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), responseType)); 
        // return handler.Handle(request, responseType, cancellationToken);
        
        throw new NotImplementedException();
    }
}