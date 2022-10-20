using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Taller.DTOs
{
    public class TipoVehiculoCreacionDTO
    {


        [Required]

        [StringLength(50)]
        public string DescripciónTipo { get; set; }

       
    }
}
