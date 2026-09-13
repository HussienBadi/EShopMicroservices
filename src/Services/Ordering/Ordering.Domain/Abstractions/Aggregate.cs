
namespace Ordering.Domain.Abstractions
{
    // The main purpose of Aggregate<T> is to give every Aggregate Root the ability to collect Domain Events.
    public abstract class Aggregate<TId> : Entity<TId>,IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainEvent = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvent.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }
        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequeuedEvents = _domainEvent.ToArray();

            _domainEvent.Clear();

            return dequeuedEvents;
        }
    }
}
