using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class TipoRequisitoRepositorio : IRepositorio<TipoRequisito>
    {
        private readonly MiDbContext _context;

        public TipoRequisitoRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TipoRequisito entity)
        {
            await _context.TiposRequisito.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.TiposRequisito.AnyAsync(x => x.Id == id);
        }

        public async Task<List<TipoRequisito>> GetAllAsync()
        {
            return await _context.TiposRequisito.ToListAsync();
        }


        public void Update(TipoRequisito entity)
        {
            _context.Update(entity);
        }

        public async Task<TipoRequisito?> GetByIdAsync(Guid id)
        {
            return await _context.TiposRequisito.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TipoRequisito?> GetByNombreAsync(string nombre)
        {
            return await _context.TiposRequisito.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
    }
}
