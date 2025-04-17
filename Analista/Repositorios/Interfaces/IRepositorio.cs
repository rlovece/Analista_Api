

namespace Analista.Repositorios.Interfaces
{
    public interface IRepositorio<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);

        // void Delete(T entity); Se utiliza borrado lógico.
        Task<bool> ExistsAsync(Guid id);

    }
}
