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
        public virtual ICollection<CondicionPorCasoDeUso> CondicionPorCasoDeUso { get; set; }

        [JsonIgnore]
        public virtual ICollection<CriterioDeAceptacion> CriterioDeAceptacion { get; set;  }

        [JsonIgnore]
        public virtual ICollection<Actor> Actor { get; set; }

        [JsonIgnore]
        public virtual ICollection<Servicio> Servicio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Requisito> Requisito { get; set; }


    }
}
