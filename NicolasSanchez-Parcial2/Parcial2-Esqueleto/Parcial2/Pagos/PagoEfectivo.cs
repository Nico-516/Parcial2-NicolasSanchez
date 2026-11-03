namespace Parcial2.Pagos
{
    // Estrategia concreta: pago en efectivo al retirar. 10 % de descuento.
    // Ya está resuelta: usala de MODELO para el TODO 4.
    public class PagoEfectivo : IPagoStrategy
    {
        public const decimal Descuento = 0.10m;

        public string Nombre => "Efectivo";
        public bool PermiteCuotas => false;
        public bool RequiereCuit => false;

        public decimal CalcularAjuste(decimal subtotal, int cuotas)
        {
            return -subtotal * Descuento;
        }
    }
}
