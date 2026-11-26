using System;

namespace MindCare.Models
{
    public class DiarioPessoal
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Entrada { get; set; }

        public Usuario Usuario { get; set; }
    }
}