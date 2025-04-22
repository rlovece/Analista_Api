using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class TipoRequisito : ComponenteDeCasoDeUso
    {

        public int Orden { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [JsonIgnore]
        public virtual ICollection<SubTipoRequisito>? SubTipoRequisito { get; set; }
    }
}