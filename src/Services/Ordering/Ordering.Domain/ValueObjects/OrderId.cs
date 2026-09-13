namespace Ordering.Domain.ValueObjects
{
    public record OrderId
    {
        public Guid Value { get; set; }
        private OrderId(Guid value) => Value = value;

        public static OrderId Of(Guid Value)
        {
            ArgumentNullException.ThrowIfNull(Value);

            if (Value == Guid.Empty)
            {
                throw new DomainException("OrderId Can not be empty");
            }
            return new OrderId(Value);
        }
    }
}
