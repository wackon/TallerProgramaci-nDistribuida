using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Entidades
{
    public class Detalle
    {


        //Primary  key- Identity(1,1)

        [Required]
        public int Id { get; set; }

        [Required]

        [StringLength(500)]
        public string Observacion { get; set; }

        public int IdHistorial { get; set; }

        [ForeignKey("IdHistorial")]
        public Historial Historial { get; set;  }



    }
}
