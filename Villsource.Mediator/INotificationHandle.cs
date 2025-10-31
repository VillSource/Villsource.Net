using Villsource.Mediator.Abstractions;

namespace Villsource.Mediator;

public interface INotificationHandle<in TNotification>
    where TNotification : INotification
{
    Task Handle(TNotification notification, CancellationToken cancellationToken = default);
}