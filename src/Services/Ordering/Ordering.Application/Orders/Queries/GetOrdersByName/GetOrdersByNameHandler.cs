namespace Ordering.Application.Orders.Queries.GetOrderByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext dbContext) 
        : IQueryHandler<GetOrdersByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            var order = await dbContext.Orders
                .Include(x => x.OrderItems)
                .AsNoTracking()
                .Where(x => x.OrderName.Value.Contains(query.Name))
                .OrderBy(x => x.OrderName.Value)
                .ToListAsync(cancellationToken);

            var orderDto = order.ToOrderDtoList();
            return new GetOrderByNameResult(orderDto);

        }
    }
}
