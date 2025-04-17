using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Analista.Models
{
    public abstract class ComponenteDeCasoDeUso
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Nombre no puede tener más de 150 caracteres")]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [DefaultValue(true)]
        public Boolean Activo { get; set; }

    }
}