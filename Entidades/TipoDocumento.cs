using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Entidades
{
    public class TipoDocumento
    {

        public int Id { get; set; }

        [Required]

        [StringLength(100)]
        public string DescTipoDocumento { get; set; }

        public IdentityUser IdUser { get; set; }

    }
}
