using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent :INotification
    {
        //By inheriting from INotification, every domain event automatically becomes a MediatR notification.
        Guid EventId => Guid.NewGuid();
        public DateTime? OccurredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
