using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class CriterioDeAceptacionPorCasoDeUso : ComponentePorCasoDeUso
    {

        [ForeignKey("CriterioDeAceptacion")]
        public Guid IdCriterioDeAceptacion { get; set; }

        public virtual CriterioDeAceptacion CriterioDeAceptacion { get; set; }
   
    }
}