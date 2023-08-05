namespace CrudTest.Domain.Common;

public class DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        this.OccurredOn = DateTime.Now;
    }

    public DateTime OccurredOn { get; }
    Guid CorrelationEventId { get; set; }
}