using Microsoft.Extensions.DependencyInjection;
using Villsource.Mediator.Abstractions;

namespace Villsource.Mediator.Handlers;

public class Publisher(IServiceProvider serviceProvider): IPublisher
{
    public Task Publish(object notification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
    {
        var handlers = serviceProvider.GetServices<INotificationHandle<TNotification>>();
        await Task.WhenAll(handlers.Select(h => h.Handle(notification, cancellationToken)));
    }
}