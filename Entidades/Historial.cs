using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Entidades
{
    public class Historial
    {

        //Primary  key- Identity(1,1)
        public int Id { get; set; }

        [Required]

        [StringLength(50)]
        public int NumeroDocumento { get; set; }
        public int IdVehiculo { get; set; }

        public DateTime FechaIngreso { get; set; }

        [ForeignKey("IdVehiculo")]
        public Vehiculo Vehiculo { get; set; }

        public IdentityUser IdUser { get; set; }

    }
}
