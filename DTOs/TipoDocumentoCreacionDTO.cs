using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Taller.DTOs
{
    public class TipoDocumentoCreacionDTO
    {

        [Required]

        [StringLength(100)]
        public string DescTipoDocumento { get; set; }

        public IdentityUser IdUser { get; set; }

    }
}

