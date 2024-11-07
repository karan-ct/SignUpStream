using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignUpStream.Data.Entities
{

    public class Subscription
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		[ForeignKey("User")]
		public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("PricePlan")]
		public int PricePlanId { get; set; }
        public virtual PricePlan PricePlan { get; set; }

        [ForeignKey("PromoCode")]
		public int? PromoCodeId { get; set; }
        public virtual PromoCode? PromoCode { get; set; }

        public int TotalBranch { get; set; }
		public decimal TotalAmount { get; set; }
        public bool PaymentSuccessful { get; set; }
		public string PaymentError { get; set; }

        public Subscription()
		{
            PaymentError = "";
        }
	}
}

