using System;
using System.Collections.Generic;

namespace Parcial2.Pagos
{
    // TODO 5 · Factory
    // La forma de pago se elige EN EJECUCIÓN y llega como TEXTO (del ComboBox o del JSON).
    // Este es el ÚNICO lugar del sistema que conoce las clases concretas de pago.
    public static class PagoFactory
    {
        public static IPagoStrategy Crear(string tipo)
        {
            switch (tipo)
            {
                case "Efectivo": return new PagoEfectivo();
                case "Tarjeta de credito": return new PagoTarjeta();
                case "Cuenta corriente": return new PagoCuentaCorriente();
                default: throw new ArgumentException($"No existe el metodo de pago ´{tipo}´");
            }
            // Recibe el texto ("Tarjeta de crédito") y devuelve la estrategia correcta.
            // Si el texto no corresponde a ninguna, ArgumentException con un mensaje claro.
        }

        // La usa el ComboBox: la vista no escribe nombres a mano.
        public static List<string> TiposDisponibles()
        {
            return new List<string> { "Efectivo", "Tarjeta de crédito", "Cuenta corriente" };
        }
    }
}
