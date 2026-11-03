using System;
using System.Collections.Generic;
using System.Linq;
using Parcial2.Models;
using Parcial2.Observer;
using Parcial2.Pagos;
using Parcial2.Repository;

namespace Parcial2.Controllers
{
    // PATRÓN OBSERVER — este controller es el Notificador (Publisher).
    // Hace su trabajo (validar, calcular, guardar) y AVISA. No sabe quién escucha.
    public class OrdenController : IOrdenPublisher
    {
        private readonly IRepository<OrdenTrabajo> _ordenes;
        private readonly IRepository<Servicio> _servicios;
        private readonly List<IOrdenObserver> suscriptores = new List<IOrdenObserver>();

        // TODO 7 · Observer
        // Este controller tiene que ser el Notificador: guardar la lista de suscriptores,
        // permitir el alta y la baja, y avisarles a todos cuando algo pasa.

        public OrdenController(IRepository<OrdenTrabajo> ordenes, IRepository<Servicio> servicios)
        {
            _ordenes = ordenes;
            _servicios = servicios;
        }

        public void Suscribir(IOrdenObserver observador)
        {
            if (!suscriptores.Contains(observador))
            {
                suscriptores.Add(observador);
                return;
            }
            throw new ArgumentException("El observador ya estaba suscrito");
        }

        public void Desuscribir(IOrdenObserver observador)
        {
            suscriptores.Remove(observador);
        }

        private void Notificar(EventoOrden evento)
        {
            foreach(var o in suscriptores)
            {
                o.Actualizar(evento);
            }
        }

        // ------------------------------------------------------------------ CONSULTAS

        public List<Servicio> ObtenerCatalogo()
        {
            return _servicios.LeerTodos().OrderBy(s => s.Categoria).ThenBy(s => s.Nombre).ToList();
        }

        public List<OrdenTrabajo> ObtenerOrdenes()
        {
            return _ordenes.LeerTodos().OrderByDescending(o => o.Id).ToList();
        }

        // Lo que el taller tiene que mirar: lo que entró y lo que se está reparando.
        public List<OrdenTrabajo> OrdenesEnTaller()
        {
            return _ordenes.LeerTodos()
                .Where(o => o.Estado == EstadoOrden.Ingresada || o.Estado == EstadoOrden.EnReparacion)
                .OrderBy(o => o.Id)
                .ToList();
        }

        public int Contar(EstadoOrden estado)
        {
            return _ordenes.LeerTodos().Count(o => o.Estado == estado);
        }

        public decimal Facturacion()
        {
            return _ordenes.LeerTodos().Where(o => o.Estado != EstadoOrden.Cancelada).Sum(o => o.Total);
        }

        public List<string> FormasDePago()
        {
            return PagoFactory.TiposDisponibles();
        }

        // La vista lo usa para habilitar "Cuotas" y "CUIT" según la forma de pago elegida.
        public IPagoStrategy InfoPago(string tipo)
        {
            return PagoFactory.Crear(tipo);
        }

        // ------------------------------------------------------------------ ARMADO DE LA ORDEN

        public OrdenTrabajo NuevoBorrador()
        {
            return new OrdenTrabajo();
        }

        public void AgregarItem(OrdenTrabajo borrador, int idServicio, int cantidad)
        {
            Servicio servicio = _servicios.BuscarPorId(idServicio);
            borrador.AgregarItem(servicio, cantidad);
        }

        // TODO 6 · Controller
        // CotizarPago: usá la factory para obtener la estrategia y delegale el cálculo (redondeado a 0 decimales).
        // ConfirmarOrden: validar, completar el borrador, calcular ajuste y total, guardar
        //                 y notificar el alta (TODO 7). Reglas en el README.

        public decimal CotizarPago(string tipoPago, decimal subtotal, int cuotas)
        {
            IPagoStrategy estrategia = PagoFactory.Crear(tipoPago);
            return Math.Round(estrategia.CalcularAjuste(subtotal, cuotas),0);
        }

        public OrdenTrabajo ConfirmarOrden(OrdenTrabajo borrador, string cliente, string telefono,
                                           string patente, string cuit, int cuotas, string tipoPago)
        {
            if (string.IsNullOrWhiteSpace(cliente) || string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El cliente y el telefono son obligatorios.");
            }
            if (borrador.Items.Count == 0 || borrador.Items == null)
            {
                throw new ArgumentException("No se puede confirmar una orden sin servicios o vacia.");
            }
            if (patente.ToUpper().Trim().Count() != 6 || patente.ToUpper().Trim().Count() != 7)
            {
                throw new ArgumentException("La patente tiene que tener entre 6 o 7 numeros y letras.");
            }
            IPagoStrategy estrategia = PagoFactory.Crear(tipoPago);
            if (estrategia.RequiereCuit == true && string.IsNullOrWhiteSpace(cuit))
            {
                throw new ArgumentException($"Para el tipo de pago ´{tipoPago}´, se requiere que ingrese un cuit");
            }
            if (estrategia.PermiteCuotas == false) { cuotas = 1; }
            if (estrategia.RequiereCuit == false) { cuit = ""; }
            decimal total = Math.Round(estrategia.CalcularAjuste(borrador.CalcularSubtotal(), cuotas),0);
            borrador.Estado = EstadoOrden.Ingresada;
            DateTime fechaDeAlta = DateTime.Now;


            // Aca no lo llegue a completar por falta de tiempo

        }

        // ------------------------------------------------------------------ OPERACIONES

        public void AvanzarEstado(int id)
        {
            OrdenTrabajo orden = BuscarOFallar(id);
            EstadoOrden anterior = orden.Estado;
            orden.AvanzarEstado();
            _ordenes.Actualizar(orden);

            Notificar(new EventoOrden(TipoEvento.CambioEstado, orden, anterior));
        }

        public void Cancelar(int id)
        {
            OrdenTrabajo orden = BuscarOFallar(id);
            EstadoOrden anterior = orden.Estado;
            orden.Cancelar();
            _ordenes.Actualizar(orden);

            Notificar(new EventoOrden(TipoEvento.Cancelacion, orden, anterior));
        }

        private OrdenTrabajo BuscarOFallar(int id)
        {
            return _ordenes.BuscarPorId(id) ?? throw new InvalidOperationException($"No existe la orden #{id}.");
        }
    }
}
