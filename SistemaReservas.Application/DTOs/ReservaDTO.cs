namespace SistemaReservas.API.Models
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaServicio { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }

        // Propiedades de los modelos relacionados (Cliente, Servicio)
        public ClienteDTO Cliente { get; set; } = null!;
        public ServicioDTO Servicio { get; set; } = null!;
    }
}
