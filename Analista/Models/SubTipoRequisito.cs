using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class SubTipoRequisito : ComponenteDeCasoDeUso
    {

        public int Orden {  get; set; }

        [ForeignKey("TipoRequisito")]
        public Guid IdTipoRequisito { get; set; }


        public DateTime? FechaModificacion { get; set; }


        public virtual TipoRequisito TipoRequisito { get; set; }

        [JsonIgnore]
        public virtual ICollection<Requisito> Requisito { get; set; }
    }
}