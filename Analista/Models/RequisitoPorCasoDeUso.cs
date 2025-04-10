using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class RequisitoPorCasoDeUso
    {
        public Guid Id { get; set; }

        [ForeignKey("CasoDeUso")]
        public Guid IdCasodeUso { get; set; }

        [ForeignKey("Requisito")]
        public Guid IdRequisito { get; set; }

        public virtual CasoDeUso CasoDeUso { get; set; }
        public virtual Requisito Requisito { get; set; }

    }
}