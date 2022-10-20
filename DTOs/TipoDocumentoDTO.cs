using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Taller.DTOs
{
    public class TipoDocumentoDTO
    {


        public int Id { get; set; }

        [Required]

        [StringLength(100)]
        public string DescTipoDocumento { get; set; }

        public IdentityUser IdUser { get; set; }
    }
}

