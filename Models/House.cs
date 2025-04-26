
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_insurance.Models
{
    [Table("houses")]
    public class House
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HouseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public required User Owner { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Image { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public int YearBuild { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public required string ConstructionType { get; set; }

        [Required]
        public required string HomeOccupancy { get; set; }

        public bool? AgentVerified { get; set; }
    }
}