using System;
using System.IO;
using System.Text;
using Parcial2.Models;

namespace Parcial2.Comprobantes
{
    // PATRÓN FACTORY METHOD — Creador
    // Su responsabilidad PRINCIPAL es armar el comprobante (la lógica de negocio), UNA sola vez.
    // Lo único que delega a las subclases es QUÉ formato usar: el método fábrica CrearFormato().
    public abstract class GeneradorComprobante
    {
        public abstract string Descripcion { get; }   // "Comprobante de texto"
        public abstract string Extension { get; }     // "txt"

        protected abstract IFormatoComprobante CrearFormato();

        public void Generar(OrdenTrabajo orden, string ruta)
        {
            if (orden.Estado == EstadoOrden.Cancelada)
                throw new InvalidOperationException($"La orden #{orden.Id} está cancelada: no se emite comprobante.");

            IFormatoComprobante formato = CrearFormato();   // <- acá se usa el Factory Method

            formato.Encabezado(orden);
            foreach (ItemOrden item in orden.Items)
                formato.Item(item);
            formato.Totales(orden.CalcularSubtotal(), orden.Ajuste, orden.Total);

            File.WriteAllText(ruta, formato.Resultado(), Encoding.UTF8);
        }
    }
}
