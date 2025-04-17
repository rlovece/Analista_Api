using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public class CasoDeUso
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Nombre no puede tener más de 150 caracteres")]
        public String  Nombre { get; set; }

        public String Descripcion {  get; set; }
       
        public int Orden {  get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; } 

        [DefaultValue(true)]
        public Boolean Activo { get; set; }

        [JsonIgnore]
        public virtual ICollection<CondicionPorCasoDeUso> CondicionesPorCasoDeUso { get; set; }

        [JsonIgnore]
        public virtual ICollection<CriterioDeAceptacionPorCasoDeUso> CriteriosDeAceptacionPorCasoDeUso { get; set;  }

        [JsonIgnore]
        public virtual ICollection<ActorPorCasoDeUso> ActoresPorCasoDeUso { get; set; }

        [JsonIgnore]
        public virtual ICollection<ServiciosPorCasoDeUso> ServiciosPorCasoDeUso { get; set; }

        [JsonIgnore]
        public virtual ICollection<RequisitoPorCasoDeUso> RequisitoPorCasoDeUso { get; set; }


    }
}
