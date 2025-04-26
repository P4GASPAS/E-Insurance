
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_insurance.Models
{
    [Table("claims")]
    public class Claim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimId { get; set; }

        [Required]
        public int InsuranceId { get; set; }

        [ForeignKey("InsuranceId")]
        public required Insurance Insurance { get; set; }

        [Required]
        public DateTime ClaimDateTime { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public required string Status { get; set; }

        [Required]
        public DateTime ReleaseDateTime { get; set; }
    }
}