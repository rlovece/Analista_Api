using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class Servicio : ComponenteDeCasoDeUso
    {
        
        public string Descripcion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [JsonIgnore]
        public virtual ICollection<ServiciosPorCasoDeUso> serviciosPorCasoDeUso { get; set; }
    }
}