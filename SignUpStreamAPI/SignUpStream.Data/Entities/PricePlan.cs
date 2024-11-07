using SignUpStream.Infra.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignUpStream.Data.Entities
{
    public class PricePlan
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public MembershipPlanTypes MembershipPlanType { get; set; }
        public bool Active { get; set; } = true;
	}
}

