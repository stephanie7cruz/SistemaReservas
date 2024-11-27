using SistemaReservas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Application.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task AddAsync(Reserva reserva);
        Task UpdateAsync(Reserva reserva);
        Task DeleteAsync(Reserva reserva);
    }
}
