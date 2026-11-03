using Parcial2.Models;

namespace Parcial2.Comprobantes
{
    // PATRÓN FACTORY METHOD — Producto
    // Un formato sabe CÓMO se escribe cada parte del comprobante. Va acumulando texto,
    // por eso hace falta uno NUEVO por cada comprobante.
    public interface IFormatoComprobante
    {
        void Encabezado(OrdenTrabajo orden);
        void Item(ItemOrden item);
        void Totales(decimal subtotal, decimal ajuste, decimal total);
        string Resultado();
    }
}
