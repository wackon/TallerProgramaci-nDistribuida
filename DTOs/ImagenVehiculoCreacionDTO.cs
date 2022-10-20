using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Entidades;

namespace Taller.DTOs
{
    public class ImagenVehiculoCreacionDTO
    {
        [Required]
        
        public int IdVehiculo { get; set; }
        public IFormFile Foto { get; set; }

        [ForeignKey("IdVehiculo")]

        public Vehiculo Vehiculo { get; set; }
    }
}
