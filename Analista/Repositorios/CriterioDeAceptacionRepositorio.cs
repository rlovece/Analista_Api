using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class CriterioDeAcpetacionRepositorio : IRepositorio<CriterioDeAceptacion>
    {
        private readonly MiDbContext _context;

        public CriterioDeAcpetacionRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CriterioDeAceptacion entity)
        {
            await _context.CriteriosDeAceptacion.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.CriteriosDeAceptacion.AnyAsync(x => x.Id == id);
        }

        public async Task<List<CriterioDeAceptacion>> GetAllAsync()
        {
            return await _context.CriteriosDeAceptacion.ToListAsync();
        }

        public async Task<CriterioDeAceptacion?> GetByIdAsync(Guid id)
        {
            return await _context.CriteriosDeAceptacion.FindAsync(id);
        }


        public void Update(CriterioDeAceptacion entity)
        {
            _context.Update(entity);
        }

        Task<CriterioDeAceptacion> IRepositorio<CriterioDeAceptacion>.GetByNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
