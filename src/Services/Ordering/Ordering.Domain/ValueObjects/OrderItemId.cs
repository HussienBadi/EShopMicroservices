namespace Ordering.Domain.ValueObjects
{
    public record OrderItemId
    {
        public Guid Value { get; set; }
        private OrderItemId(Guid value) => Value = value;

        public static OrderItemId Of(Guid Value)
        {
            ArgumentNullException.ThrowIfNull(Value);

            if (Value == Guid.Empty)
            {
                throw new DomainException("OrderItemId Can not be empty");
            }
            return new OrderItemId(Value);
        }
      
    }
}
