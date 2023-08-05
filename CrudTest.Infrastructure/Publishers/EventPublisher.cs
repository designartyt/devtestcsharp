using CrudTest.Application.Common;
using CrudTest.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrudTest.Infrastructure.Publishers;

public class EventPublisher:IEventPublisher
{
    private readonly ILogger<EventPublisher> _logger;
    private readonly IPublisher _mediator;

    public EventPublisher(ILogger<EventPublisher> logger, IPublisher mediator) =>
        (_logger, _mediator) = (logger, mediator);

    public Task PublishAsync(DomainEvent @event)
    {
        _logger.LogInformation("Publishing Event : {event}", @event.GetType().Name);
        var pub = _mediator.Publish((INotification)@event);
        return pub;
    }
}