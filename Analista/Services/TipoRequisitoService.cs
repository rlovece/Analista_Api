using Analista.Models;
using Analista.Repositorios.Interfaces;
using Analista.Services.Interfaces;

namespace Analista.Services
{
    public class TipoRequisitoService : ITipoRequisitoService
    {
        private IRepositorio<TipoRequisito> _TipoRequisitoRepositorio;

        public TipoRequisitoService(IRepositorio<TipoRequisito> tipoRequisitoRepositorio)
        {
            _TipoRequisitoRepositorio = tipoRequisitoRepositorio;
        }

        public Task<TipoRequisito> CreateAsync(TipoRequisito entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoRequisito>> GetAllAsync()
        {
            return await _TipoRequisitoRepositorio.GetAllAsync();
        }

        public Task<TipoRequisito?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, TipoRequisito entity)
        {
            throw new NotImplementedException();
        }
    }
}
