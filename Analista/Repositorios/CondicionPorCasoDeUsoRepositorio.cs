using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class CondicionPorCasoDeUsoRepositorio : IRepositorio<CondicionPorCasoDeUso>
    {
        private readonly MiDbContext _context;

        public CondicionPorCasoDeUsoRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CondicionPorCasoDeUso entity)
        {
            await _context.CondicionesPorCasosDeUso.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.CondicionesPorCasosDeUso.AnyAsync(x => x.Id == id);
        }

        public async Task<List<CondicionPorCasoDeUso>> GetAllAsync()
        {
            return await _context.CondicionesPorCasosDeUso.ToListAsync();
        }

        public async Task<CondicionPorCasoDeUso?> GetByIdAsync(Guid id)
        {
            return await _context.CondicionesPorCasosDeUso.FindAsync(id);
        }


        public void Update(CondicionPorCasoDeUso entity)
        {
            _context.Update(entity);
        }

        Task<CondicionPorCasoDeUso> IRepositorio<CondicionPorCasoDeUso>.GetByNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
