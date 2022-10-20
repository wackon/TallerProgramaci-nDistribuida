using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Taller.DTOs;

namespace Taller.Entidades
{
    public class TipoVehiculo
    {
        
        public int Id { get; set; }


        [Required]

        [StringLength(50)]
        public string DescripciónTipo { get; set; }

        
    }
}
