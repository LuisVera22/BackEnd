using System.ComponentModel.DataAnnotations;

namespace servicio.Models.ModelsDTO
{
    public class BankDTO
    {
        [Required]
        public required string BankName { get; set; }
    }
}
