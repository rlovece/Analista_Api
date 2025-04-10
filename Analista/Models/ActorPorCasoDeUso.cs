using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class ActorPorCasoDeUso
    {
        public Guid Id { get; set; }

        [ForeignKey("CasoDeUso")]
        public Guid IdCasoDeUso { get; set; }

        [ForeignKey("Condicion")]
        public Guid IdCondicion { get; set; }

        public virtual CasoDeUso CasoDeUso { get; set; }

        public virtual Actor Actor { get; set; }
    }
}