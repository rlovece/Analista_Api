using Analista.Models;

namespace Analista.Services.Interfaces
{
    public interface ISubTipoRequisitoService
    {
        Task<List<SubTipoRequisito>> GetAllAsync();
        Task<SubTipoRequisito?> GetByIdAsync(Guid id);
        Task<SubTipoRequisito> CreateAsync(SubTipoRequisito entity);
        Task<bool> UpdateAsync(Guid id, SubTipoRequisito entity);
        Task<bool> DeleteAsync(Guid id);

    }
}
