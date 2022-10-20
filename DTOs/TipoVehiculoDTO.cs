using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Taller.DTOs
{
    public class TipoVehiculoDTO
    {
        // Primary key -Identity(1,1);


        public int Id { get; set; }


        [Required]

        [StringLength(50)]
        public string DescripciónTipo { get; set; }

    }
}
