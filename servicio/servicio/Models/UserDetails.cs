using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDSWI.Models
{
    public class UserDetails
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; } // Usamos la misma clave primaria que User.

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Dni { get; set; } // Documento de Identidad.

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        public User User { get; set; }
    }
}
