namespace SistemaReservas.Domain.ValueObjects
{
    public class Telefono
    {
        public string Numero { get; }

        public Telefono(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero)) throw new ArgumentException("El número de teléfono no puede estar vacío.");
            if (numero.Length < 10) throw new ArgumentException("El número de teléfono no es válido.");

            Numero = numero;
        }

        public override string ToString() => Numero;
    }
}
