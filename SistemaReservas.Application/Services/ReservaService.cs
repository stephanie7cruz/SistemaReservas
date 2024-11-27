using SistemaReservas.Application.Interfaces;
using SistemaReservas.Domain.Entities;
using SistemaReservas.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaReservas.API.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<ReservaDTO>> GetReservasAsync()
        {
            var reservas = await _reservaRepository.GetAllAsync();
            return reservas.Select(reserva => new ReservaDTO
            {
                Id = reserva.Id,
                FechaReserva = reserva.FechaReserva,
                FechaServicio = reserva.FechaServicio,
                Cliente = new ClienteDTO
                {
                    Id = reserva.Cliente.Id,
                    Nombre = reserva.Cliente.Nombre,
                    Apellido = reserva.Cliente.Apellido
                },
                Servicio = new ServicioDTO
                {
                    Id = reserva.Servicio.Id,
                    Nombre = reserva.Servicio.Nombre,
                    Precio = reserva.Servicio.Precio
                }
            });
        }

        public async Task<ReservaDTO?> GetReservaByIdAsync(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);

            if (reserva == null)
                return null;

            return new ReservaDTO
            {
                Id = reserva.Id,
                FechaReserva = reserva.FechaReserva,
                FechaServicio = reserva.FechaServicio,
                Cliente = new ClienteDTO
                {
                    Id = reserva.Cliente.Id,
                    Nombre = reserva.Cliente.Nombre,
                    Apellido = reserva.Cliente.Apellido
                },
                Servicio = new ServicioDTO
                {
                    Id = reserva.Servicio.Id,
                    Nombre = reserva.Servicio.Nombre,
                    Precio = reserva.Servicio.Precio
                }
            };
        }

        public async Task<ReservaDTO> CreateReservaAsync(ReservaDTO reservaDTO)
        {
            var reserva = new Reserva
            {
                FechaReserva = reservaDTO.FechaReserva,
                FechaServicio = reservaDTO.FechaServicio,
                ClienteId = reservaDTO.ClienteId,
                ServicioId = reservaDTO.ServicioId
            };

            await _reservaRepository.AddAsync(reserva);
            reservaDTO.Id = reserva.Id;
            return reservaDTO;
        }

        public async Task<ReservaDTO?> UpdateReservaAsync(int id, ReservaDTO reservaDTO)
        {
            var existingReserva = await _reservaRepository.GetByIdAsync(id);

            if (existingReserva == null)
                return null;

            existingReserva.FechaReserva = reservaDTO.FechaReserva;
            existingReserva.FechaServicio = reservaDTO.FechaServicio;
            existingReserva.ClienteId = reservaDTO.ClienteId;
            existingReserva.ServicioId = reservaDTO.ServicioId;

            await _reservaRepository.UpdateAsync(existingReserva);
            return reservaDTO;
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);

            if (reserva == null)
                return false;

            await _reservaRepository.DeleteAsync(reserva);
            return true;
        }
    }
}
