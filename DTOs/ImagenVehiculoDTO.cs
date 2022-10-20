using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Entidades;

namespace Taller.DTOs
{
    public class ImagenVehiculoDTO
    {
        public int Id { get; set; }

        [Required]

        public int IdVehiculo { get; set; }
        public string Foto { get; set; }

        [ForeignKey("IdVehiculo")]

        public Vehiculo Vehiculo { get; set; }
    }
}
