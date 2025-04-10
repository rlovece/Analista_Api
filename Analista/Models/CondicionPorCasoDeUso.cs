using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class CondicionPorCasoDeUso
    {
        public Guid Id { get; set; }

        [ForeignKey("CasoDeUso")]
        public Guid IdCasoDeUso { get; set; }

        [ForeignKey("Condicion")]
        public Guid IdCondicion {  get; set; }

        public TipoCondicion Tipo { get; set; }

        public virtual CasoDeUso CasoDeUso { get; set; }

        public virtual Condicion Condicion { get; set; }

    }

    public enum TipoCondicion
    {
        PreCondicion = 1,
        PostCondicion = 2
    }
}