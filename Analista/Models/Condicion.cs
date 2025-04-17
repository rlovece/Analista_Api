using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class Condicion : ComponenteDeCasoDeUso
    {
      
        public String Descripcion { get; set; }

        public DateTime? FechaModificacion { get; set; }


        [JsonIgnore]
        public virtual ICollection<CondicionPorCasoDeUso> CondicionPorCasoDeUso { get; set; }
    }
}