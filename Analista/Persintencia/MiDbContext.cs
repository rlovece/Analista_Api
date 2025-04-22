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
        public DbSet<Condicion> Condiciones { get; set; }
        public DbSet<CondicionPorCasoDeUso> CondicionesPorCasosDeUso { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<CriterioDeAceptacion> CriteriosDeAceptacion { get; set; }
        public DbSet<SubTipoRequisito> SubTiposRequisito { get; set; }
        public DbSet<TipoRequisito> TiposRequisito { get; set; }

        public MiDbContext(DbContextOptions<MiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CasoDeUso>(e =>
            {
                e.ToTable("CasosDeUso");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.Descripcion)
                      .IsRequired();
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
                e.Property(e => e.Orden)
                      .IsRequired();
            });

            modelBuilder.Entity<CasoDeUso>()
                .HasMany(c => c.Requisito)
                .WithMany(r => r.CasoDeUso)
                .UsingEntity(j => j.ToTable("RequisitosPorCasoDeUso"));

            modelBuilder.Entity<CasoDeUso>()
               .HasMany(c => c.Servicio)
               .WithMany(r => r.CasoDeUso)
               .UsingEntity(j => j.ToTable("ServiciosPorCasoDeUso"));

            modelBuilder.Entity<CasoDeUso>()
               .HasMany(c => c.Actor)
               .WithMany(r => r.CasoDeUso)
               .UsingEntity(j => j.ToTable("ActoresPorCasoDeUso"));

            modelBuilder.Entity<CasoDeUso>()
               .HasMany(c => c.CriterioDeAceptacion)
               .WithMany(r => r.CasoDeUso)
               .UsingEntity(j => j.ToTable("CriteriosDeAceptacionPorCasoDeUso"));

            modelBuilder.Entity<CasoDeUso>()
               .HasMany(c => c.CondicionPorCasoDeUso)
               .WithOne(r => r.CasoDeUso);

            modelBuilder.Entity<Actor>(e =>
            {
                e.ToTable("Actores");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
            });

            modelBuilder.Entity<Condicion>(e =>
            {
                e.ToTable("Condiciones");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
            });

            modelBuilder.Entity<CondicionPorCasoDeUso>(e =>
            {
                e.ToTable("CondicionesPorCasosDeUso");
                e.HasKey(e => e.Id);
                e.Property(e => e.Tipo)
                      .IsRequired();
            });

            modelBuilder.Entity<CriterioDeAceptacion>(e =>
            {
                e.ToTable("CriteriosDeAceptacion");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
            });

            modelBuilder.Entity<Requisito>(e =>
            {
                e.ToTable("Requisitos");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
            });

            modelBuilder.Entity<Servicio>(e =>
            {
                e.ToTable("Servicios");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
            });

            modelBuilder.Entity<SubTipoRequisito>(e =>
            {
                e.ToTable("SubTiposRequisito");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
                e.Property(e => e.FechaCreacion)
                      .IsRequired();
            });

            modelBuilder.Entity<SubTipoRequisito>()
               .HasMany(c => c.Requisito)
               .WithOne(r => r.SubTipoRequisito);

            modelBuilder.Entity<TipoRequisito>(e =>
            {
                e.ToTable("TiposRequisito");
                e.HasKey(e => e.Id);
                e.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            modelBuilder.Entity<TipoRequisito>()
               .HasMany(c => c.SubTipoRequisito)
               .WithOne(r => r.TipoRequisito);

            modelBuilder.ApplyConfiguration(new TipoRequisitoSeed());
            
        }

    }
}
