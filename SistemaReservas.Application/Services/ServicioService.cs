using SistemaReservas.Application.Interfaces;
using SistemaReservas.API.Models;
using SistemaReservas.Infrastructure.Repositories;  
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaReservas.Domain.Entities;

namespace SistemaReservas.API.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<ServicioDTO>> GetServiciosAsync()
        {
            var servicios = await _servicioRepository.GetServiciosAsync(); // Llama al repositorio
            return servicios.Select(servicio => new ServicioDTO
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                Precio = servicio.Precio  
            });
        }

        public async Task<ServicioDTO> GetServicioByIdAsync(int id)
        {
            var servicio = await _servicioRepository.GetServicioByIdAsync(id); // Llama al repositorio
            if (servicio == null) return null;

            return new ServicioDTO
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                Precio = servicio.Precio  
            };
        }

        public async Task<ServicioDTO> CreateServicioAsync(ServicioDTO servicioDto)
        {
            
            var servicio = new Servicio(servicioDto.Nombre, servicioDto.Descripcion, servicioDto.Precio);
            await _servicioRepository.CreateServicioAsync(servicio);
            servicioDto.Id = servicio.Id; 
            return servicioDto;
        }

        public async Task<ServicioDTO> UpdateServicioAsync(int id, ServicioDTO servicioDto)
        {
            
            var servicio = new Servicio(servicioDto.Nombre, servicioDto.Descripcion, servicioDto.Precio)
            {
                Id = id
            };
            await _servicioRepository.UpdateServicioAsync(id, servicio);
            return servicioDto;
        }

        public async Task<bool> DeleteServicioAsync(int id)
        {
            await _servicioRepository.DeleteServicioAsync(id);
            return true;
        }
    }
}
