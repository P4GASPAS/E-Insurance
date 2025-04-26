using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_insurance.Models
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Required]
        public int InsuranceId { get; set; }

        [ForeignKey("InsuranceId")]
        public required Insurance Insurance { get; set; }

        [Required]
        public DateTime PaymentDateTime { get; set; }

        [Required]
        public required string Status { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
