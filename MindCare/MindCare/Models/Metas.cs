using System;

namespace MindCare.Models
{
    public class Metas
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Status { get; set; }

        public Usuario Usuario { get; set; }
    }
}