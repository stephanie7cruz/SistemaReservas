using Microsoft.EntityFrameworkCore;
using SistemaReservas.Domain.Entities;

namespace SistemaReservas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Reserva>().HasKey(r => r.Id);
            modelBuilder.Entity<Servicio>().HasKey(s => s.Id);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Servicio)
                .WithMany(s => s.Reservas)
                .HasForeignKey(r => r.ServicioId);

            // Configurar precisión y escala para el campo Precio de la entidad Servicio
            modelBuilder.Entity<Servicio>()
                .Property(s => s.Precio)
                .HasColumnType("decimal(18,2)"); // Precisión de 18 y escala de 2
        }
    }
}
