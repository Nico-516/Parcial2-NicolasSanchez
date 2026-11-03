using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcial2.Models
{
    public class OrdenTrabajo : IEntidad
    {
        public const int MaximoPorItem = 10;

        public int Id { get; set; }
        public string Cliente { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Patente { get; set; } = "";
        public string Cuit { get; set; } = "";

        // Nombre de la forma de pago: "Efectivo", "Tarjeta de crédito", "Cuenta corriente".
        // En el JSON se guarda como TEXTO.
        public string FormaPago { get; set; } = "";
        public int Cuotas { get; set; } = 1;

        public List<ItemOrden> Items { get; set; } = new List<ItemOrden>();

        // Se congelan al confirmar la orden. Ajuste negativo = descuento; positivo = recargo.
        public decimal Ajuste { get; set; }
        public decimal Total { get; set; }

        public EstadoOrden Estado { get; set; } = EstadoOrden.Ingresada;
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        // TODO 2 · Modelo y validaciones. Reglas completas en el README. Resumen:
        //  - AgregarItem: solo si la orden está Ingresada (si no, InvalidOperationException);
        //    servicio obligatorio; cantidad entre 1 y MaximoPorItem; si el trabajo ya está, se SUMA la cantidad.
        //  - CalcularSubtotal: suma de los subtotales de los ítems.
        //  - AvanzarEstado: Ingresada -> EnReparacion -> Terminada -> Retirada. Una orden finalizada no avanza.
        //  - Cancelar: SOLO si está Ingresada.
        // Dato inválido: ArgumentException. Operación que no corresponde: InvalidOperationException.

        public void AgregarItem(Servicio servicio, int cantidad)
        {
            if (servicio == null)
            {
                throw new InvalidOperationException("Recuerde ingresar un servicio");
            }
            if (cantidad > MaximoPorItem || cantidad < 1)
            {
                throw new InvalidOperationException($"La cantidad valida es entre 1 y {MaximoPorItem}");
            }
            ItemOrden existe = Items.FirstOrDefault(Items => Items.Descripcion == servicio.Nombre);
            if (existe != null)
            {
                if (existe.Cantidad + cantidad > MaximoPorItem)
                {
                    throw new InvalidOperationException($"No se puede agregar mas que {MaximoPorItem}");
                }
                existe.Cantidad += cantidad;
            }
            ItemOrden nuevoItem = new ItemOrden();
            nuevoItem.Descripcion = servicio.Nombre;
            nuevoItem.PrecioUnitario = servicio.Precio;
            nuevoItem.Cantidad = cantidad;
            Items.Add(nuevoItem);
        }

        public decimal CalcularSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in Items)
            {
                subtotal += item.Subtotal;
            }
            return subtotal;
        }

        public bool EstaFinalizada()
        {
            return Estado == EstadoOrden.Retirada || Estado == EstadoOrden.Cancelada;
        }

        public void AvanzarEstado()
        {
            var estado = Estado;
            switch (estado)
            {
                case EstadoOrden.Ingresada: Estado = EstadoOrden.EnReparacion; break;
                case EstadoOrden.EnReparacion: Estado = EstadoOrden.Terminada; break;
                case EstadoOrden.Terminada: Estado = EstadoOrden.Retirada; break;
                default: throw new InvalidOperationException($"No se puede avanzar del estado´{Estado}´");
            }
        }

        public void Cancelar()
        {
            if (Estado == EstadoOrden.Ingresada)
            {
                Estado = EstadoOrden.Cancelada;
                return;
            }
            throw new InvalidOperationException("No se puede cancelar el servicio");
        }
    }
}
