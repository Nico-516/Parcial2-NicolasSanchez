using System;
using Parcial2.Models;

namespace Parcial2.Observer
{
    // El "contexto" de la notificación: QUÉ pasó, a QUÉ orden y CUÁNDO.
    public class EventoOrden
    {
        public TipoEvento Tipo { get; }
        public OrdenTrabajo Orden { get; }
        public EstadoOrden EstadoAnterior { get; }
        public DateTime Fecha { get; }

        public EventoOrden(TipoEvento tipo, OrdenTrabajo orden, EstadoOrden estadoAnterior)
        {
            Tipo = tipo;
            Orden = orden;
            EstadoAnterior = estadoAnterior;
            Fecha = DateTime.Now;
        }

        public string Descripcion()
        {
            switch (Tipo)
            {
                case TipoEvento.Alta:
                    return $"Nueva orden #{Orden.Id} - {Orden.Patente} - {Orden.Cliente} - {Orden.FormaPago} - {Orden.Total:C0}";
                case TipoEvento.CambioEstado:
                    return $"Orden #{Orden.Id} ({Orden.Patente}): {EstadoAnterior} -> {Orden.Estado}";
                default:
                    return $"Orden #{Orden.Id} ({Orden.Patente}) CANCELADA";
            }
        }
    }
}
