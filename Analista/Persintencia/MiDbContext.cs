using Microsoft.EntityFrameworkCore;
using Analista.Models;
using Analista.Persintencia.Seed;

namespace Analista.Persintencia
{
    public class MiDbContext : DbContext
    {

        public DbSet<Requisito> Requisitos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<CasoDeUso> CasosDeUso { get; set; }
        public DbSet<ActorPorCasoDeUso> ActoresPorCasosDeUso { get; set; }
        public DbSet<RequisitoPorCasoDeUso> RequisitosPorCasosDeUso { get; set; }
        public DbSet<Condicion> Condiciones { get; set; }
        public DbSet<CondicionPorCasoDeUso> CondicionesPorCasosDeUso { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServiciosPorCasoDeUso> ServiciosPorCasosDeUso { get; set; }
        public DbSet<CriterioDeAceptacion> CriteriosDeAceptacion { get; set; }
        public DbSet<CriterioDeAceptacionPorCasoDeUso> CriteriodDeAceptacionPorCasoDeUso { get; set; }
        public DbSet<SubTipoRequisito> SubTiposRequisito { get; set; }
        public DbSet<TipoRequisito> TiposRequisito { get; set; }

        public MiDbContext(DbContextOptions<MiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TipoRequisitoSeed());
        }
    }
}
