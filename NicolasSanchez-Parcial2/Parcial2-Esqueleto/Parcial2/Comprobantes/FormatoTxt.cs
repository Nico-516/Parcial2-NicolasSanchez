using System.Text;
using Parcial2.Models;

namespace Parcial2.Comprobantes
{
    // Producto concreto: comprobante de texto plano.
    public class FormatoTxt : IFormatoComprobante
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public void Encabezado(OrdenTrabajo orden)
        {
            _sb.AppendLine("==============================================");
            _sb.AppendLine("     TALLER MECÁNICO JUAN B. JUSTO");
            _sb.AppendLine("     Mar del Plata");
            _sb.AppendLine("==============================================");
            _sb.AppendLine($"Orden #{orden.Id}   {orden.FechaIngreso:dd/MM/yyyy HH:mm}");
            _sb.AppendLine($"Cliente: {orden.Cliente}");
            _sb.AppendLine($"Vehículo: {orden.Patente}");
            _sb.AppendLine($"Pago: {orden.FormaPago}" + (orden.Cuotas > 1 ? $" en {orden.Cuotas} cuotas" : ""));
            if (!string.IsNullOrWhiteSpace(orden.Cuit))
                _sb.AppendLine($"CUIT: {orden.Cuit}");
            _sb.AppendLine("----------------------------------------------");
        }

        public void Item(ItemOrden item)
        {
            _sb.AppendLine($"{item.Cantidad,3} x {item.Descripcion,-28}{item.Subtotal,12:C0}");
        }

        public void Totales(decimal subtotal, decimal ajuste, decimal total)
        {
            _sb.AppendLine("----------------------------------------------");
            _sb.AppendLine($"{"Subtotal",-34}{subtotal,12:C0}");
            _sb.AppendLine($"{(ajuste < 0 ? "Descuento" : "Recargo"),-34}{ajuste,12:C0}");
            _sb.AppendLine($"{"TOTAL",-34}{total,12:C0}");
            _sb.AppendLine("==============================================");
        }

        public string Resultado()
        {
            return _sb.ToString();
        }
    }
}
