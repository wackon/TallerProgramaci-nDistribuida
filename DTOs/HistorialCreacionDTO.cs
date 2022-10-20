using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Entidades;

namespace Taller.DTOs
{
    public class HistorialCreacionDTO
    {
        
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
