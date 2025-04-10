using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class ServiciosPorCasoDeUso
    {
        public Guid Id { get; set; }

        [ForeignKey("CasoDeUso")]
        public Guid IdCasoDeUso { get; set; }

        [ForeignKey("Servicio")]
        public Guid IdServicio { get; set; }
        public virtual CasoDeUso CasoDeUso { get; set; }
        public virtual Servicio Servicio { get; set; }


    }
}