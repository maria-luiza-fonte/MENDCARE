using System;

namespace MindCare.Models
{
    public class CheckinHumor
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Humor { get; set; }
        public string Comentario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
