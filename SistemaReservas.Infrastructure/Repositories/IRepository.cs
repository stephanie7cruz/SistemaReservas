using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();  // Obtener todos los elementos
        Task<T> GetByIdAsync(int id);        // Obtener un elemento por su ID
        Task AddAsync(T entity);              // Agregar un nuevo elemento
        Task UpdateAsync(T entity);           // Actualizar un elemento
        Task DeleteAsync(int id);             // Eliminar un elemento
    }
}
