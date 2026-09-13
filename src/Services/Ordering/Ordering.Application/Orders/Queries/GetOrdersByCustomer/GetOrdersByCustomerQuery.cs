namespace Ordering.Application.Orders.Queries.GetOrderByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId):IQuery<GetOrderByCustomerResult>;
public record GetOrderByCustomerResult(IEnumerable<OrderDto> Orders);
