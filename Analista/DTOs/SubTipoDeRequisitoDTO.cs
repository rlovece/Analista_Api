
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class SubTipoRequisitoDTO : ComponenteDeCasoDeUso
    {

        public int? Orden { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Guid? IdTipoRequisito { get; set; }

        [JsonIgnore]
        public ICollection<Requisito>? Requisito { get; set; }
    }
}