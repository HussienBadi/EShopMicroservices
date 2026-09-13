namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string CardName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string Expiration { get; set; } = default!;
        public string CVV { get; set; } = default!;
        public int PaymentMethod { get; set; } = default!;

        
        // allows frameworks to instantiate the object
        protected Payment() { }

        // stops invalid object creation
        private Payment (string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            CardName = cardName; CardNumber = cardNumber; Expiration = expiration; CVV = cvv; PaymentMethod = paymentMethod;
        }

        // validates data before creating the object
        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }
    }
}
