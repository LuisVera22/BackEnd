using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDSWI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public DateTime Birthdate { get; set; }
        public int LegalGuardianId { get; set; }


        //Relations
        [ForeignKey("LegalGuardianId")]
        public LegalGuardian LegalGuardian { get; set; }

        //Relationship whit the table Payment and Quota
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Quota> Quotas { get; set; }
    }
}
