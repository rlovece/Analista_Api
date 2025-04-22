using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class RequisitoRepositorio : IRepositorio<Requisito>
    {
        private readonly MiDbContext _context;

        public RequisitoRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Requisito entity)
        {
            await _context.Requisitos.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Requisitos.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Requisito>> GetAllAsync()
        {
            return await _context.Requisitos.ToListAsync();
        }

        public async Task<Requisito?> GetByIdAsync(Guid id)
        {
            return await _context.Requisitos.FindAsync(id);
        }


        public void Update(Requisito entity)
        {
            _context.Update(entity);
        }

        Task<Requisito> IRepositorio<Requisito>.GetByNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
