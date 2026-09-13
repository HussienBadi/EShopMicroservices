using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventsHandlers.Domain
{
    public class OrderCreateEventHandler(IPublishEndpoint publishEndpoint, IFeatureManager featureManager, ILogger<OrderCreateEvent> logger)
        : INotificationHandler<OrderCreateEvent>
    {
        public async Task Handle(OrderCreateEvent orderCreateEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Domain Event Handler : {orderCreateEvent.GetType().Name}");

            if(await featureManager.IsEnabledAsync("OrderFullfilment"))
            {
                var orderCreatedIntegrationEvent = orderCreateEvent.Order.ToOrderDto();
                await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
            }
        }
    }
}
