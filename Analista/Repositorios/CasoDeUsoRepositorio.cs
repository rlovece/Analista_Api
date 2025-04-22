using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class CasoDeUsoRepositorio : IRepositorio<CasoDeUso>
    {
        private readonly MiDbContext _context;

        public CasoDeUsoRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CasoDeUso entity)
        {
            await _context.CasosDeUso.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.CasosDeUso.AnyAsync(x => x.Id == id);
        }

        public async Task<List<CasoDeUso>> GetAllAsync()
        {
            return await _context.CasosDeUso.ToListAsync();
        }

        public async Task<CasoDeUso?> GetByIdAsync(Guid id)
        {
            return await _context.CasosDeUso.FindAsync(id);
        }


        public void Update(CasoDeUso entity)
        {
            _context.Update(entity);
        }

        Task<CasoDeUso> IRepositorio<CasoDeUso>.GetByNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
