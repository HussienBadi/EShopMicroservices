namespace Ordering.Application.Orders.Queries.GetOrderByCustomer
{
    public class GetOrdersByCustomerHandler (IApplicationDbContext dbContext)
        : IQueryHandler<GetOrdersByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            var order = await dbContext.Orders
                .Include(x => x.OrderItems)
                .AsNoTracking()
                .Where(x => x.CustomerId == CustomerId.Of(query.CustomerId))
                .OrderBy(x=>x.OrderName.Value)
                .ToListAsync();

            return new GetOrderByCustomerResult(order.ToOrderDtoList());
        }
    }
}
