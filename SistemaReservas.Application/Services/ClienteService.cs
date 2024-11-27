using SistemaReservas.Application.Interfaces;
using SistemaReservas.API.Models;
using SistemaReservas.Infrastructure.Repositories; 
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaReservas.Domain.Entities;

namespace SistemaReservas.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Implementación asíncrona de GetClientesAsync
        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();  // Llamada al repositorio
            // Convierte clientes a DTO y devuelve
            return clientes.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido
            });
        }

        // Implementación asíncrona de GetClienteByIdAsync
        public async Task<ClienteDTO> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);  // Llamada al repositorio
            if (cliente == null)
                return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido
            };
        }

        // Implementación asíncrona de CreateClienteAsync
        public async Task<ClienteDTO> CreateClienteAsync(ClienteDTO clienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido
            };
            await _clienteRepository.AddAsync(cliente);
            clienteDto.Id = cliente.Id;  // Asigna el ID generado
            return clienteDto;
        }

        // Implementación asíncrona de UpdateClienteAsync
        public async Task<ClienteDTO> UpdateClienteAsync(int id, ClienteDTO clienteDto)
        {
            var cliente = new Cliente
            {
                Id = id,
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido
            };
            await _clienteRepository.UpdateAsync(cliente);
            return clienteDto;
        }

        // Implementación asíncrona de DeleteClienteAsync
        public async Task<bool> DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            return true;
        }
    }
}
