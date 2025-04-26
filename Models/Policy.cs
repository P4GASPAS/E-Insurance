
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_insurance.Models
{
    [Table("policies")]
    public class Policy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyId { get; set; }

        [Required]
        public required string InsuranceType { get; set; }

        [Required]
        public double MonthlyPayment { get; set; }

        [Required]
        public double ActivationFee { get; set; }

        [Required]
        public double DwellingCoverage { get; set; }

        [Required]
        public double PersonalPropertyCoverage { get; set; }

        [Required]
        public double LiabilityCoverage { get; set; }

        [Required]
        public double AdditionalLivingExpenses { get; set; }

        [Required]
        public double NaturalCalamities { get; set; }

        [Required]
        public int ContractLengthMonths { get; set; }
    }
}