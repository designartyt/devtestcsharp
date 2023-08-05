using CrudTest.Domain.Common;

namespace CrudTest.Application.Common;

public interface IEventPublisher
{
    Task PublishAsync(DomainEvent @event);
}