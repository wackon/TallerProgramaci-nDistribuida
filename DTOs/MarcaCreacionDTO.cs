using System.ComponentModel.DataAnnotations;

namespace Taller.DTOs
{
    public class MarcaCreacionDTO
    {
        
        [Required]

        [StringLength(50)]
        public string NombreMarca { get; set; }

       
    }
}
