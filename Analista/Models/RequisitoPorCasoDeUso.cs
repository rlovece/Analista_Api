using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class RequisitoPorCasoDeUso : ComponentePorCasoDeUso
    {

        [ForeignKey("Requisito")]
        public Guid IdRequisito { get; set; }

        public virtual Requisito Requisito { get; set; }

    }
}