using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Parcial2.Comprobantes;
using Parcial2.Controllers;
using Parcial2.Models;
using Parcial2.Observer;
using Parcial2.Services;

namespace Parcial2.Views
{
    // El formulario principal es un suscriptor más: cuando algo cambia, el controller le avisa.
    public partial class FormPrincipal : Form, IOrdenObserver
    {
        private readonly OrdenController _controller;
        private readonly ComprobanteController _comprobantes;

        public FormPrincipal(OrdenController controller, ComprobanteController comprobantes)
        {
            InitializeComponent();
            _controller = controller;
            _comprobantes = comprobantes;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Refrescar();
            Bitacora.Instancia.Registrar("Sistema iniciado");
        }

        // ------------------------------------------------------------------ OBSERVER

        public void Actualizar(EventoOrden evento)
        {
            Refrescar();
        }

        // ------------------------------------------------------------------ BOTONES

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using var form = new FormNuevaOrden(_controller);
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            int? id = IdSeleccionado();
            if (id == null) return;

            try
            {
                _controller.AvanzarEstado(id.Value);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int? id = IdSeleccionado();
            if (id == null) return;

            if (MessageBox.Show($"¿Cancelar la orden #{id}?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _controller.Cancelar(id.Value);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            int? id = IdSeleccionado();
            if (id == null) return;

            List<GeneradorComprobante> generadores = _comprobantes.GeneradoresDisponibles();

            using var dialogo = new SaveFileDialog
            {
                Filter = string.Join("|", generadores.Select(g => $"{g.Descripcion} (*.{g.Extension})|*.{g.Extension}")),
                FileName = $"orden_{id:0000}"
            };
            if (dialogo.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                GeneradorComprobante elegido = generadores[dialogo.FilterIndex - 1];   // FilterIndex arranca en 1
                _comprobantes.Generar(elegido, id.Value, dialogo.FileName);
                Bitacora.Instancia.Registrar($"Comprobante de la orden #{id} ({elegido.Descripcion})");
                MessageBox.Show("Comprobante generado.", "Taller JBJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnTaller_Click(object sender, EventArgs e)
        {
            // Probá abrir DOS pantallas del taller: las dos se tienen que actualizar solas.
            try
            {
                var taller = new FormTaller(_controller);
                taller.Show(this);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            using var form = new FormBitacora();
            form.ShowDialog(this);
        }

        // ------------------------------------------------------------------ AUXILIARES

        private void Refrescar()
        {
            try
            {
                dgvOrdenes.DataSource = _controller.ObtenerOrdenes()
                    .Select(o => new
                    {
                        o.Id,
                        o.Patente,
                        o.Cliente,
                        Pago = o.Cuotas > 1 ? $"{o.FormaPago} ({o.Cuotas} cuotas)" : o.FormaPago,
                        Trabajos = o.Items.Sum(i => i.Cantidad),
                        Total = o.Total.ToString("C0"),
                        Estado = o.Estado.ToString(),
                        Ingreso = o.FechaIngreso.ToString("dd/MM HH:mm")
                    })
                    .ToList();

                lblResumen.Text =
                    $"Ingresadas: {_controller.Contar(EstadoOrden.Ingresada)}   ·   " +
                    $"En reparación: {_controller.Contar(EstadoOrden.EnReparacion)}   ·   " +
                    $"Terminadas: {_controller.Contar(EstadoOrden.Terminada)}   ·   " +
                    $"Retiradas: {_controller.Contar(EstadoOrden.Retirada)}   ·   " +
                    $"Facturado: {_controller.Facturacion():C0}";
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private int? IdSeleccionado()
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una orden de la lista.", "Taller JBJ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return (int)dgvOrdenes.CurrentRow.Cells["Id"].Value;
        }

        private void MostrarError(Exception ex)
        {
            Bitacora.Instancia.Registrar("ERROR: " + ex.Message);
            MessageBox.Show(ex.Message, "No se pudo completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
