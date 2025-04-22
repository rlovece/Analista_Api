using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public abstract class ComponenteDeCasoDeUsoDTO
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public Boolean? Activo { get; set; }

    }
}