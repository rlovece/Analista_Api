using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class CondicionRepositorio : IRepositorio<Condicion>
    {
        private readonly MiDbContext _context;

        public CondicionRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Condicion entity)
        {
            await _context.Condiciones.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Condiciones.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Condicion>> GetAllAsync()
        {
            return await _context.Condiciones.ToListAsync();
        }

        public async Task<Condicion?> GetByIdAsync(Guid id)
        {
            return await _context.Condiciones.FindAsync(id);
        }


        public void Update(Condicion entity)
        {
            _context.Update(entity);
        }
    }
}
