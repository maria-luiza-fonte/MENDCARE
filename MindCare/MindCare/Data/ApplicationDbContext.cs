using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MindCare.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
    public DbSet<MindCare.Models.GraficosEvolucao> GraficosEvolucao { get; set; } = default!;
    public DbSet<MindCare.Models.Metas> Metas { get; set; } = default!;
    public DbSet<MindCare.Models.DiarioPessoal> DiarioPessoal { get; set; } = default!;
    public DbSet<MindCare.Models.CheckinHumor> CheckinHumor { get; set; } = default!;
    }
}
