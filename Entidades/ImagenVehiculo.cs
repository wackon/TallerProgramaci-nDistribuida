using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Entidades
{
    public class ImagenVehiculo
    {

        //Primary  key- Identity(1,1)

        public int Id { get; set; }

        [Required]

        public int IdVehiculo { get; set; }
        public string Foto { get; set; }

        [ForeignKey("IdVehiculo")]

        public Vehiculo Vehiculo { get; set; }


    }
}
