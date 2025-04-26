
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_insurance.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public int? AgentId { get; set; }

        [ForeignKey("AgentId")]
        public User? Agent { get; set; }

        public ICollection<User>? Clients { get; set; }

        public string? Avatar { get; set; }

        [Required]
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public string? Contact { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public bool? EmailVerified { get; set; }

        public string? Password { get; set; }

        public string? Status { get; set; }

        public string? Role { get; set; }
    }
}