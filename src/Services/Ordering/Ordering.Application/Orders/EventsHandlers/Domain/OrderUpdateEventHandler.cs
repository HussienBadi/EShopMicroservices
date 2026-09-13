namespace Ordering.Application.Orders.EventsHandlers.Domain
{
   

    public class OrderUpdateEventHandler(ILogger<UpdateOrderEvent> logger) : INotificationHandler<UpdateOrderEvent>
    {
        public Task Handle(UpdateOrderEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Domain Event Handler : {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}
