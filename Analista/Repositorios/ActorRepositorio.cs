using Analista.Models;
using Analista.Persintencia;
using Analista.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace Analista.Repositorios
{
    public class ActorRepositorio : IRepositorio<Actor>
    {
        private readonly MiDbContext _context;

        public ActorRepositorio(MiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor entity)
        {
            await _context.Actores.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Actores.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _context.Actores.ToListAsync();
        }

        public async Task<Actor?> GetByIdAsync(Guid id)
        {
            return await _context.Actores.FindAsync(id);
        }


        public void Update(Actor entity)
        {
            _context.Update(entity);
        }
    }
}
