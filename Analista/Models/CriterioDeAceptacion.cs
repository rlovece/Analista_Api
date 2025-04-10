using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Analista.Models
{
    public class CriterioDeAceptacion
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Nombre no puede tener más de 150 caracteres")]
        public String Nombre { get; set; }

        public String Descripcion { get; set; }


        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

        [DefaultValue(true)]
        public Boolean Activo { get; set; }

        public virtual ICollection<CriterioDeAceptacionPorCasoDeUso> CriterioDeAceptacionPorCasoDeUsos { get; set; }
    }
}