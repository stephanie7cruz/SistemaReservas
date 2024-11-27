using Microsoft.EntityFrameworkCore;
using SistemaReservas.Domain.Entities;
using SistemaReservas.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.Infrastructure.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AppDbContext _context;

        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servicio>> GetServiciosAsync()
        {
            return await _context.Servicios.ToListAsync();  // Obtiene todos los servicios de la base de datos
        }

        public async Task<Servicio> GetServicioByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);  // Obtiene un servicio por su ID
        }

        public async Task<Servicio> CreateServicioAsync(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);    // Agrega un nuevo servicio
            await _context.SaveChangesAsync();              // Guarda los cambios en la base de datos
            return servicio;
        }

        public async Task<Servicio> UpdateServicioAsync(int id, Servicio servicio)
        {
            var existingServicio = await _context.Servicios.FindAsync(id);
            if (existingServicio != null)
            {
                existingServicio.Nombre = servicio.Nombre;
                existingServicio.Descripcion = servicio.Descripcion;
                _context.Servicios.Update(existingServicio);   // Actualiza el servicio
                await _context.SaveChangesAsync();             // Guarda los cambios en la base de datos
                return existingServicio;
            }
            return null;
        }

        public async Task<bool> DeleteServicioAsync(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);           // Elimina el servicio
                await _context.SaveChangesAsync();             // Guarda los cambios en la base de datos
                return true;
            }
            return false;
        }
    }
}
