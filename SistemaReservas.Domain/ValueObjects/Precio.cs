public class Precio
{
    public decimal Valor { get; private set; }
    public string Moneda { get; private set; }

    public Precio(decimal valor, string moneda)
    {
        if (valor <= 0) throw new ArgumentException("El valor debe ser mayor a cero.");
        Valor = valor;
        Moneda = moneda;
    }

    public override string ToString() => $"{Valor} {Moneda}";

    // Métodos adicionales como comparación o conversión de moneda podrían ser agregados
}
