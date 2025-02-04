using System.ComponentModel.DataAnnotations;

namespace ProyectoDSWI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        // Relación muchos a muchos con usuarios
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
