namespace SignUpStream.Infra.Models
{
    public class SubscriptionVM
	{
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int PricePlanId { get; set; }
        public int PromoCodeId { get; set; }
        public int TotalBranch { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentSuccessful { get; set; }
        public string PaymentError { get; set; }
	}
}

