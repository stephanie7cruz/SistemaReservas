using System;

namespace SistemaReservas.Domain.ValueObjects
{
    public class Direccion : IEquatable<Direccion>
    {
        public string Calle { get; }
        public string Ciudad { get; }
        public string CodigoPostal { get; }
        public string Pais { get; }

        // Constructor
        public Direccion(string calle, string ciudad, string codigoPostal, string pais)
        {
            if (string.IsNullOrWhiteSpace(calle)) throw new ArgumentException("La calle no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(ciudad)) throw new ArgumentException("La ciudad no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(codigoPostal)) throw new ArgumentException("El código postal no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(pais)) throw new ArgumentException("El país no puede estar vacío.");

            Calle = calle;
            Ciudad = ciudad;
            CodigoPostal = codigoPostal;
            Pais = pais;
        }

        // Comparación para saber si dos direcciones son iguales
        public bool Equals(Direccion other)
        {
            if (other == null) return false;
            return Calle == other.Calle && Ciudad == other.Ciudad && CodigoPostal == other.CodigoPostal && Pais == other.Pais;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Direccion);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Calle, Ciudad, CodigoPostal, Pais);
        }

        // Método para obtener una representación legible de la dirección
        public override string ToString()
        {
            return $"{Calle}, {Ciudad}, {CodigoPostal}, {Pais}";
        }
    }
}

