namespace Ordering.Domain.Events
{
   public record UpdateOrderEvent(Order Order) : IDomainEvent;
}
