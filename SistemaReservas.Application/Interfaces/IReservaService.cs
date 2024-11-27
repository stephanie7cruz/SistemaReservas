using SistemaReservas.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Application.Interfaces
{
    public interface IReservaService
    {
        Task<IEnumerable<ReservaDTO>> GetReservasAsync();
        Task<ReservaDTO> GetReservaByIdAsync(int id);
        Task<ReservaDTO> CreateReservaAsync(ReservaDTO reservaDTO);
        Task<ReservaDTO> UpdateReservaAsync(int id, ReservaDTO reservaDTO);
        Task<bool> DeleteReservaAsync(int id);
    }
}
