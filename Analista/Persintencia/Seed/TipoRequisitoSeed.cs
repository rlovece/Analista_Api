using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Analista.Models;
using System.ComponentModel;

namespace Analista.Persintencia.Seed
{
    public class TipoRequisitoSeed : IEntityTypeConfiguration<TipoRequisito>
    {

        public void Configure(EntityTypeBuilder<TipoRequisito> builder)
        {
            builder.HasData(
                    new TipoRequisito
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000001"),
                        Nombre = "Requisito No Funcional",
                        Orden = 1,
                        FechaCreacion = new DateTime(2024, 4, 10, 14, 30, 0, DateTimeKind.Utc),
                        Activo = true
                    },
                    new TipoRequisito
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000002"),
                        Nombre = "Requisito Funcional",
                        Orden = 2,
                        FechaCreacion = new DateTime(2024, 4, 10, 14, 30, 0, DateTimeKind.Utc),
                        Activo = true
                    }
);
        }
    }
}
