using SistemaReservas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SistemaReservas.API.Services;
using SistemaReservas.Application.Interfaces;
using SistemaReservas.Application.Mappings;
using SistemaReservas.Infrastructure.Repositories; 

public class Program
{
    public static void Main(string[] args)
    {
        // Crear la aplicación
        var builder = WebApplication.CreateBuilder(args);

        // Agregar servicios al contenedor
        builder.Services.AddControllers(); // Agregar soporte para controladores
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configuración de la base de datos
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext"))
        );

        // Configurar AutoMapper
        builder.Services.AddAutoMapper(typeof(ClienteMappingProfile), typeof(ReservaMappingProfile), typeof(ServicioMappingProfile));

        // Registrar servicios y repositorios
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IReservaService, ReservaService>();
        builder.Services.AddScoped<IServicioService, ServicioService>();

        // Registrar los repositorios
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>(); // Repositorio para Cliente
        builder.Services.AddScoped<IReservaRepository, ReservaRepository>(); // Repositorio para Reserva
        builder.Services.AddScoped<IServicioRepository, ServicioRepository>(); // Repositorio para Servicio

        // Crear la aplicación
        var app = builder.Build();

        // Configurar el pipeline de solicitud HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers(); // Mapea automáticamente los controladores

        // Iniciar la aplicación
        app.Run();
    }
}
