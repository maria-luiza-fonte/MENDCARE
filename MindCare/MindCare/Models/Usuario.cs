using Microsoft.AspNetCore.Identity;
using System;

namespace MindCare.Models
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Genero { get; set; }
    }
}
