namespace Parcial2.Pagos
{
    // PATRÓN STRATEGY — la interfaz Estrategia
    // TODO 4 · Strategy: creá en esta carpeta PagoTarjeta y PagoCuentaCorriente (reglas en el README).
    // "Toda forma de pago recibe el subtotal y las cuotas, y devuelve el ajuste:
    //  negativo si es descuento, positivo si es recargo."
    public interface IPagoStrategy
    {
        string Nombre { get; }

        // ¿Admite pagar en cuotas? ¿Exige CUIT? Cada estrategia lo sabe:
        // así ni el controller ni la vista preguntan "if (tipo == ...)".
        bool PermiteCuotas { get; }
        bool RequiereCuit { get; }

        decimal CalcularAjuste(decimal subtotal, int cuotas);
    }
}
