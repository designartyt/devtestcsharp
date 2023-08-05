using System.ComponentModel.DataAnnotations.Schema;

namespace CrudTest.Domain.Common;

public abstract class AggregateRoot:Entity,IAggregateRoot
{
    private List<DomainEvent> _domainEvents;
[NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<DomainEvent>();
        this._domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}