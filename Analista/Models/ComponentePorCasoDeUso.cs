using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public abstract class ComponentePorCasoDeUsoDTO
    {
        public Guid Id { get; set; }

        [ForeignKey("CasoDeUso")]
        public Guid IdCasoDeUso { get; set; }

        public virtual CasoDeUso CasoDeUso { get; set; }

    }
}