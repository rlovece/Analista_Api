using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class Requisito
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Nombre no puede tener más de 150 caracteres")]
        public String  Nombre { get; set; }

        public String Descripcion {  get; set; }
        
        public int Orden {  get; set; }

        [ForeignKey("SubTipoRequisito")]
        public Guid IdSubTipoRequisito { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

        [DefaultValue(true)]
        public Boolean Activo { get; set; }

        public virtual SubTipoRequisito subTipoRequisito { get; set; }


    }
}
