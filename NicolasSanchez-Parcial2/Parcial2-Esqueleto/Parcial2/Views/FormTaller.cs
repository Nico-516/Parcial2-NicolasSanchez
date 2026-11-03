using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Parcial2.Controllers;
using Parcial2.Models;
using Parcial2.Observer;

namespace Parcial2.Views
{
    // Pantalla del taller. Puede haber varias abiertas a la vez (una por cada box).
    // PATRÓN OBSERVER — suscriptor que entra y sale en tiempo de ejecución.
    public partial class FormTaller : Form, IOrdenObserver
    {
        private readonly OrdenController _controller;

        public FormTaller(OrdenController controller)
        {
            InitializeComponent();
            _controller = controller;
            Refrescar();

            // TODO 7: esta pantalla tiene que enterarse sola de cada cambio. ¿Qué falta acá?
        }

        public void Actualizar(EventoOrden evento)
        {
            Refrescar();
            lstEventos.Items.Insert(0, $"{evento.Fecha:HH:mm:ss}  {evento.Descripcion()}");
        }

        private void FormTaller_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO 7: ¿qué tiene que pasar cuando se cierra una pantalla del taller?
        }

        private void Refrescar()
        {
            List<OrdenTrabajo> enTaller = _controller.OrdenesEnTaller();

            lstPendientes.Items.Clear();
            foreach (OrdenTrabajo orden in enTaller)
            {
                lstPendientes.Items.Add($"#{orden.Id}  {orden.Patente}  {orden.Estado.ToString().ToUpper()}  ·  {orden.Cliente}");
                foreach (ItemOrden item in orden.Items)
                    lstPendientes.Items.Add($"        {item.Cantidad} x {item.Descripcion}");
            }

            lblPendientes.Text = $"Vehículos en el taller: {enTaller.Count}";
        }
    }
}
