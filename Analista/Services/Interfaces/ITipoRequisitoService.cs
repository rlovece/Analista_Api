using Analista.Models;

namespace Analista.Services.Interfaces
{
    public interface ITipoRequisitoService
    {
        Task<List<TipoRequisito>> GetAllAsync();
        Task<TipoRequisito?> GetByIdAsync(Guid id);
        Task<TipoRequisito> CreateAsync(TipoRequisito entity);
        Task<bool> UpdateAsync(Guid id, TipoRequisito entity);
        Task<bool> DeleteAsync(Guid id);

    }
}
