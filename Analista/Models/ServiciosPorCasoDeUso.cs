using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class ServiciosPorCasoDeUso : ComponentePorCasoDeUso
    {

        [ForeignKey("Servicio")]
        public Guid IdServicio { get; set; }

        public virtual Servicio Servicio { get; set; }


    }
}