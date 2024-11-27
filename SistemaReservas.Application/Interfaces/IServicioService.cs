using SistemaReservas.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Application.Interfaces
{
    public interface IServicioService
    {
        Task<IEnumerable<ServicioDTO>> GetServiciosAsync();
        Task<ServicioDTO> GetServicioByIdAsync(int id);
        Task<ServicioDTO> CreateServicioAsync(ServicioDTO servicioDTO);
        Task<ServicioDTO> UpdateServicioAsync(int id, ServicioDTO servicioDTO);
        Task<bool> DeleteServicioAsync(int id);
    }
}
