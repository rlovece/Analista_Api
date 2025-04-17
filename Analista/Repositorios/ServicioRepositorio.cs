using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class ServicioRepositorio : IRepositorio<Servicio>
    {
        private readonly MiDbContext _context;

        public ServicioRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Servicio entity)
        {
            await _context.Servicios.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Servicios.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Servicio>> GetAllAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio?> GetByIdAsync(Guid id)
        {
            return await _context.Servicios.FindAsync(id);
        }


        public void Update(Servicio entity)
        {
            _context.Update(entity);
        }
    }
}
