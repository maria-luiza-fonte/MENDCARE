using System;

namespace MindCare.Models
{
    public class ConteudosEducativos
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime? DataPublicacao { get; set; }
    }
}