using System.ComponentModel.DataAnnotations;
using ProyectoDSWI.Models;
namespace servicio.Models
{
    public class GradoSeccion
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } // Ejemplo: "5to Primaria - A"

        // Relación con Estudiantes
        public ICollection<Student> Estudiantes { get; set; } = new List<Student>();

        // Relación con AsignacionesDocente
        public ICollection<AsignacionDocente> Asignaciones { get; set; } = new List<AsignacionDocente>();

        // Relación con Horario
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
    }
}
