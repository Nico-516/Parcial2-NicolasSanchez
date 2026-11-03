using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Parcial2.Services;

namespace Parcial2.Views
{
    public partial class FormBitacora : Form
    {
        public FormBitacora()
        {
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            // Si Bitacora no es un Singleton de verdad, esta lista aparece vacía (TODO 3).
            List<string> entradas = Bitacora.Instancia.ObtenerEntradas();

            if (entradas.Count == 0)
                lstEntradas.Items.Add("(La bitácora está vacía)");
            else
                lstEntradas.Items.AddRange(entradas.ToArray());
        }
    }
}
