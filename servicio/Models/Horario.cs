using System.ComponentModel.DataAnnotations;

namespace servicio.Models
{
    public class Horario
    {
        public int Id { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        [Required]
        public string DiaSemana { get; set; } // Lunes, Martes, etc.

        // Relación con GradoSeccion
        public int GradoSeccionId { get; set; }
        public GradoSeccion GradoSeccion { get; set; }

        // Relación con AsignaciónDocente
        public int AsignacionDocenteId { get; set; }
        public AsignacionDocente AsignacionDocente { get; set; }
    }
}