using Analista.Enums;
using Analista.Models;

namespace Analista.Services.Interfaces
{
    public interface ITipoRequisitoService
    {
        Task<List<TipoRequisito>> GetAllAsync();
        Task<TipoRequisito?> GetByIdAsync(Guid id);
        Task<TipoRequisito> CreateAsync(TipoRequisitoDTO entity);
        Task<bool> UpdateAsync(Guid id, TipoRequisitoDTO entity);
        Task<ResultadoEliminacion> DeleteAsync(Guid id);

    }
}
