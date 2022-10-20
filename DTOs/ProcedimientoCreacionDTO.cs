using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Entidades;

namespace Taller.DTOs
{
    public class ProcedimientoCreacionDTO
    {
   
        [Required]

        [StringLength(500)]
        public string DetalleProcedimiento { get; set; }

        public int IdDetalle { get; set; }

        [ForeignKey("IdDetalle")]
        public Detalle Detalle { get; set; }
    }
}
