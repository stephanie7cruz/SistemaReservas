﻿using SistemaReservas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();                  // Obtiene todos los clientes
        Task<Cliente> GetByIdAsync(int id);                         // Obtiene un cliente por su ID
        Task AddAsync(Cliente cliente);                             // Agrega un nuevo cliente
        Task UpdateAsync(Cliente cliente);                          // Actualiza un cliente
        Task DeleteAsync(int id);                                   // Elimina un cliente por su ID
    }
}
