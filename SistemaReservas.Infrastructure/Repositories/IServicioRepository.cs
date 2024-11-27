using SistemaReservas.Domain.Entities;

namespace SistemaReservas.Infrastructure.Repositories
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetServiciosAsync(); // Obtiene todos los servicios
        Task<Servicio> GetServicioByIdAsync(int id);     // Obtiene un servicio por su ID
        Task<Servicio> CreateServicioAsync(Servicio servicio);  // Crea un nuevo servicio
        Task<Servicio> UpdateServicioAsync(int id, Servicio servicio);  // Actualiza un servicio
        Task<bool> DeleteServicioAsync(int id);          // Elimina un servicio
    }
}
