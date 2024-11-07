using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignUpStream.Data.Entities
{
    public class PromoCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Code { get; set; }
        public decimal Discount { get; set; }
        public bool Active { get; set; } = true;

        public PromoCode()
		{
		}
	}
}

