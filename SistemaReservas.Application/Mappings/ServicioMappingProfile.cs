using AutoMapper;
using SistemaReservas.API.Models;
using SistemaReservas.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaReservas.Application.Mappings
{
    public class ServicioMappingProfile : Profile
    {
        public ServicioMappingProfile()
        {
            CreateMap<Servicio, ServicioDTO>().ReverseMap();
        }
    }
}

