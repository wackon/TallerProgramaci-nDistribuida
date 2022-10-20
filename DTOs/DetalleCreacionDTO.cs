using System.ComponentModel.DataAnnotations;

namespace Taller.DTOs
{
    public class DetalleCreacionDTO
    {
        [Required]

        [StringLength(500)]
        public string observacion { get; set; }
        public int IdHistorial { get; set; }
    }
}