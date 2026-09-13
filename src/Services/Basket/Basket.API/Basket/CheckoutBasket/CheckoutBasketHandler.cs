
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);
    public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            RuleFor(x => x.BasketCheckoutDto).Null().WithMessage("BasketCheckoutDto Can not be null");
            RuleFor(x => x.BasketCheckoutDto.UserName).Null().WithMessage("UserName Can not be null");
        }
    }
    public class CheckoutBasketHandler(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            var username = command.BasketCheckoutDto.UserName;

            var basket = await basketRepository.GetBasket(username, cancellationToken);

            if (basket == null)
            {
                throw new BasketNotFoundException(username);
            }

            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;

            await publishEndpoint.Publish(eventMessage,cancellationToken);

            await basketRepository.DeleteBasket(username,cancellationToken);

            return new CheckoutBasketResult(true);



        }
    }
}
