namespace SistemaReservas.Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaServicio { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;
    }
}
