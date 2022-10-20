using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Taller.Models
{
    public class IdentityModels : IdentityUser
    {
        public int Id { get; set; }

        public  int NumeroDocumento { get; set; }

        [MaxLength(11)]
        public int Movil { get; set; }

    }
}
