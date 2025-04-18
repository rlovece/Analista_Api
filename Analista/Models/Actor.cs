using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class Actor : ComponenteDeCasoDeUso
    {

        [JsonIgnore]
        public virtual ICollection<CasoDeUso> CasoDeUso { get; set; }
    }
}