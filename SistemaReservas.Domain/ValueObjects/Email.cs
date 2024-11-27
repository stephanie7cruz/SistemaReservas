namespace SistemaReservas.Domain.ValueObjects
{
    public class Email
    {
        public string Direccion { get; }

        public Email(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion)) throw new ArgumentException("El correo electrónico no puede estar vacío.");
            if (!direccion.Contains("@")) throw new ArgumentException("El correo electrónico no es válido.");

            Direccion = direccion;
        }

        public override string ToString() => Direccion;
    }
}
