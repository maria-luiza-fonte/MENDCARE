namespace MindCare.Models
{
    public class GraficosEvolucao
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string TipoGrafico { get; set; }
        public string Dados { get; set; }

        public Usuario Usuario { get; set; }
    }
}