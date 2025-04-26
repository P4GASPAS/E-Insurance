
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_insurance.Models
{
    [Table("insurances")]
    public class Insurance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsuranceId { get; set; }

        [Required]
        public int HouseId { get; set; }

        [ForeignKey("HouseId")]
        public required House House { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public required Policy Policy { get; set; }

        [Required]
        public DateTime DateTimeStarted { get; set; }

        [Required]
        public DateTime LastPaymentDateTime { get; set; }

        [Required]
        public required string InsuranceStatus { get; set; }

        [Required]
        public required int GracePeriod { get; set; }
    }
}