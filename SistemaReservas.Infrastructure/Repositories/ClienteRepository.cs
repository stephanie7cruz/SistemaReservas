using Microsoft.EntityFrameworkCore;
using SistemaReservas.Domain.Entities;
using SistemaReservas.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();    // Obtiene todos los clientes de la base de datos
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);    // Busca un cliente por su ID
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);       // Agrega un nuevo cliente
            await _context.SaveChangesAsync();               // Guarda los cambios en la base de datos
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);               // Actualiza un cliente en la base de datos
            await _context.SaveChangesAsync();               // Guarda los cambios en la base de datos
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);  // Busca el cliente por su ID
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);           // Elimina el cliente
                await _context.SaveChangesAsync();           // Guarda los cambios en la base de datos
            }
        }
    }
}
