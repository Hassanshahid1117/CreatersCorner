using CreatersCorner.WebApi.Shared.Events;

namespace CreatersCorner.WebApi.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}