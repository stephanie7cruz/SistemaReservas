using AutoMapper;
using SistemaReservas.API.Models;
using SistemaReservas.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaReservas.Application.Mappings
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
