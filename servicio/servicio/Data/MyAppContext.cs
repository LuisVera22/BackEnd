using Microsoft.EntityFrameworkCore;
using ProyectoDSWI.Models;
using servicio.Models;

namespace servicio.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UsersDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<LegalGuardian> LegalGuardians { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        //public DbSet<Docente> Docentes { get; set; }
        //public DbSet<Horario> Horarios { get; set; }
        //public DbSet<GradoSeccion> GradoSecciones { get; set; }
        //public DbSet<AsignacionDocente> AsignacionesDocentes { get; set; }
        //public DbSet<Matricula> Matriculas { get; set; }
    }
}
