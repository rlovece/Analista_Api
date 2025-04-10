using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analista.Models
{
    public class SubTipoRequisito
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Nombre no puede tener más de 150 caracteres")]
        public String Nombre { get; set; }

        public int Orden {  get; set; }

        [ForeignKey("TipoRequisito")]
        public Guid IdTipoRequisito { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

        [DefaultValue(true)]    
        public Boolean Activo { get; set; }

        public virtual TipoRequisito TipoRequisito { get; set; }

        public virtual ICollection<Requisito> Requisitos { get; set; }
    }
}