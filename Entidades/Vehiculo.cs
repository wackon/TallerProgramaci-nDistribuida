using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Entidades
{
    public class Vehiculo
    {

        //Primary  key- Identity(1,1)
        [StringLength(6)]
        [Required]
        public int Id { get; set; }

        [Required]


        [StringLength(6)]

        public string Placa { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public int IdMarca { get; set; }

        public int IdTipoVehiculo { get; set; }

        [ForeignKey("IdMarca")]
        public Marca Marca { get; set; }

        [ForeignKey("IdTipoVehiculo")]
        public TipoVehiculo Tipovehiculo { get; set; }

        public IdentityUser IdUser { get; set; }

    }
}
