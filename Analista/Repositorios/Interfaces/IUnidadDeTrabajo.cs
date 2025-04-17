using Analista.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Analista.Repositorios.Interfaces
{
    public interface IUnidadDeTrabajo
    {
        IRepositorio<SubTipoRequisito> _subTipoRequisitoRepositorio { get; }
        IRepositorio<TipoRequisito> _TipoRequisitoRepositorio { get; }

        void GuardarCambiosAsync();
        void Dispose();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
