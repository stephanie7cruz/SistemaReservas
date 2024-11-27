using System;
using System.Collections.Generic;

namespace SistemaReservas.Domain.Entities
{
    public class Servicio
    {
        public int Id { get; set; }

        // Nombre del servicio
        public string Nombre { get; set; } = string.Empty;

        // Descripción del servicio
        public string Descripcion { get; set; } = string.Empty;

        // Precio del servicio
        public decimal Precio { get; set; }

        // Relación con Reservas: un servicio puede tener múltiples reservas
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Constructor para crear un servicio con los parámetros esenciales
        public Servicio(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }

        
        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            Precio = nuevoPrecio;
        }

       
    }
}
