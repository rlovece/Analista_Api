using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class Requisito : ComponenteDeCasoDeUso
    {

        public String Descripcion {  get; set; }
        
        public int Orden {  get; set; }

        [ForeignKey("SubTipoRequisito")]
        public Guid IdSubTipoRequisito { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual SubTipoRequisito SubTipoRequisito { get; set; }

        public virtual ICollection<CasoDeUso> CasoDeUso { get; set; }


    }
}
