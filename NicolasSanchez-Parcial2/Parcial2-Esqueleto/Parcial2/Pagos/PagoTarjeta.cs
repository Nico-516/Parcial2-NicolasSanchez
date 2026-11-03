using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2.Pagos
{
    internal class PagoTarjeta : IPagoStrategy
    {
        public string Nombre => "Tarjeta de crédito";
        public bool PermiteCuotas => true;
        public bool RequiereCuit => false;
        public decimal CalcularAjuste(decimal subtotal, int cuotas)
        {
            switch (cuotas)
            {
                case 1: return subtotal;
                case 3: return subtotal + (subtotal * 0.10m);
                case 6: return subtotal + (subtotal * 0.20m);
                default: throw new InvalidOperationException("Solo se permite 1, 3 o 6 cuotas con tarjeta.");
            }
        }
    }
}
