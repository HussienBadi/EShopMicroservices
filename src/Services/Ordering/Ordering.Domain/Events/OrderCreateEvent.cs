

namespace Ordering.Domain.Events
{
    public record OrderCreateEvent(Order Order) : IDomainEvent;
   
}
