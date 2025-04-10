using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class CriterioDeAceptacionPorCasoDeUso
    {
        public Guid Id { get; set; }

        [ForeignKey("CasoDeUso")]
        public Guid IdCasoDeUso { get; set; }

        [ForeignKey("CriterioDeAceptacion")]
        public Guid IdCriterioDeAceptacion { get; set; }

        public virtual CasoDeUso CasoDeUso { get; set; }

        public virtual CriterioDeAceptacion CriterioDeAceptacion { get; set; }
   
    }
}