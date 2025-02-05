namespace servicio.Models
{
    public class AsignacionDocente
    {
        public int Id { get; set; }

        public int DocenteId { get; set; }
        public Docente Docente { get; set; }

        public int GradoSeccionId { get; set; }
        public GradoSeccion GradoSeccion { get; set; }

        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
    }
}
