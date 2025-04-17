using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class ActorPorCasoDeUso : ComponentePorCasoDeUso
    {

        [ForeignKey("Condicion")]
        public Guid IdCondicion { get; set; }

        public virtual Actor Actor { get; set; }
    }
}