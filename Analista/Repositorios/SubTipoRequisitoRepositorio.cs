using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class SubTipoRequisitoRepositorio : IRepositorio<SubTipoRequisito>
    {
        private readonly MiDbContext _context;

        public SubTipoRequisitoRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SubTipoRequisito entity)
        {
            await _context.SubTiposRequisito.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.SubTiposRequisito.AnyAsync(x => x.Id == id);
        }

        public async Task<List<SubTipoRequisito>> GetAllAsync()
        {
            return await _context.SubTiposRequisito
                .Include(s => s.TipoRequisito)
                .ToListAsync();
        }

        public async Task<SubTipoRequisito?> GetByIdAsync(Guid id)
        {
            return await _context.SubTiposRequisito
                .Include(s => s.TipoRequisito)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Update(SubTipoRequisito entity)
        {
            _context.Update(entity);
        }

        public async Task<SubTipoRequisito?> GetByNombreAsync(String nombre)
        {
            return await _context.SubTiposRequisito
                .Include(s => s.TipoRequisito)
                .FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
    }
}
