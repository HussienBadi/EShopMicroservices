namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;
public record UpdateOrderResult(bool Success);

public class UpdateOrderCommandVlidation : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandVlidation()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("ID should not be empty");
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
    }
}