using System;
using System.Collections.Generic;
using Parcial2.Comprobantes;
using Parcial2.Models;
using Parcial2.Repository;

namespace Parcial2.Controllers
{
    public class ComprobanteController
    {
        private readonly IRepository<OrdenTrabajo> _ordenes;

        public ComprobanteController(IRepository<OrdenTrabajo> ordenes)
        {
            _ordenes = ordenes;
        }

        // El SaveFileDialog arma sus filtros con esta lista.
        // Formato nuevo = una clase creadora nueva + UNA línea acá.
        public List<GeneradorComprobante> GeneradoresDisponibles()
        {
            return new List<GeneradorComprobante>
            {
                new GeneradorComprobanteTxt()
                // TODO 8 · Factory Method: sumá acá el generador HTML (una línea).
            };
        }

        public void Generar(GeneradorComprobante generador, int idOrden, string ruta)
        {
            OrdenTrabajo orden = _ordenes.BuscarPorId(idOrden)
                ?? throw new InvalidOperationException($"No existe la orden #{idOrden}.");

            generador.Generar(orden, ruta);
        }
    }
}
