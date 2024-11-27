using SistemaReservas.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<ClienteDTO> GetClienteByIdAsync(int id);
        Task<ClienteDTO> CreateClienteAsync(ClienteDTO clienteDTO);
        Task<ClienteDTO> UpdateClienteAsync(int id, ClienteDTO clienteDTO);
        Task<bool> DeleteClienteAsync(int id);
    }
}

