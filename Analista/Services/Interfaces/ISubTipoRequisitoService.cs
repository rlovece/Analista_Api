using Analista.Models;
using Analista.Utilidades.Enums;

namespace Analista.Services.Interfaces
{
    public interface ISubTipoRequisitoService
    {
        Task<List<SubTipoRequisito>> GetAllAsync();
        Task<SubTipoRequisito?> GetByIdAsync(Guid id);
        Task<SubTipoRequisito> CreateAsync(SubTipoRequisitoDTO entity);
        Task<bool> UpdateAsync(Guid id, SubTipoRequisitoDTO entity);
        Task<ResultadoEliminacion> DeleteAsync(Guid id);

    }
}
