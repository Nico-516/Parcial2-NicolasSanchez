using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2.Pagos
{
    internal class PagoCuentaCorriente : IPagoStrategy
    {
        public string Nombre => "Cuenta corriente";
        public bool PermiteCuotas => false;
        public bool RequiereCuit => true;
        public decimal PrecioFijo => 3000m;
        public decimal CalcularAjuste(decimal subtotal, int cuotas)
        {
            if(subtotal > 600000)
            {
                throw new InvalidOperationException("La cuenta corriente admite ordenes hasta $600.000.");
            }
            return subtotal + (subtotal * 0.05m) + PrecioFijo;
        }
    }
}
