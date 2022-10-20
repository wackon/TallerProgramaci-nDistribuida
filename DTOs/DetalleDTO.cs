using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Entidades;

namespace Taller.DTOs
{
    public class DetalleDTO
    {


        [Required]
        public int Id { get; set; }

        [Required]

        [StringLength(500)]
        public string Observacion { get; set; }

        public int IdHistorial { get; set; }

        [ForeignKey("IdHistorial")]
        public Historial Historial { get; set; }


    }
}
