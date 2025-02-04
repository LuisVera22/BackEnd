using System.ComponentModel.DataAnnotations;

namespace ProyectoDSWI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        public string TokenRecovery { get; set; } = "no";

        // Relación uno a uno con UserDetails
        public UserDetails UserDetails { get; set; }

        // Relación muchos a muchos con roles
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
