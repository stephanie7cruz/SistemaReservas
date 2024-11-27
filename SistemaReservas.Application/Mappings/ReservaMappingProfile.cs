using AutoMapper;
using SistemaReservas.API.Models;
using SistemaReservas.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaReservas.Application.Mappings
{
    public class ReservaMappingProfile : Profile
    {
        public ReservaMappingProfile()
        {
            CreateMap<Reserva, ReservaDTO>().ReverseMap();
        }
    }
}

