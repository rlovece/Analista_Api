using Analista.Models;
using Analista.Repositorios.Interfaces;

namespace Analista.Services
{
    public class SubTipoRequisitoService : Interfaces.ISubTipoRequisitoService
    {
        private readonly ISubTipoRequisitoRepositorio _repositorio;

        public SubTipoRequisitoService(ISubTipoRequisitoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<List<SubTipoRequisito>> GetAllAsync() => _repositorio.GetAllAsync();

        public Task<SubTipoRequisito?> GetByIdAsync(Guid id) => _repositorio.GetByIdAsync(id);

        public async Task<SubTipoRequisito> CreateAsync(SubTipoRequisito entity)
        {
            await _repositorio.AddAsync(entity);
            await _repositorio.SaveAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Guid id, SubTipoRequisito entity)
        {
            if (id != entity.Id || !await _repositorio.ExistsAsync(id))
                return false;

            _repositorio.Update(entity);
            await _repositorio.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repositorio.GetByIdAsync(id);
            if (entity == null) return false;

            _repositorio.Delete(entity);
            await _repositorio.SaveAsync();
            return true;
        }
    }
}
