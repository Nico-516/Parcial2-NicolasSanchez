using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parcial2.Views
{
    partial class FormTaller
    {
        /// <summary>
        ///  Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblPendientes = new Label();
            lstPendientes = new ListBox();
            lblEventos = new Label();
            lstEventos = new ListBox();
            SuspendLayout();
            // 
            // lblPendientes
            // 
            lblPendientes.AutoSize = true;
            lblPendientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPendientes.Location = new Point(12, 9);
            lblPendientes.Name = "lblPendientes";
            lblPendientes.TabIndex = 0;
            lblPendientes.Text = "Vehículos en el taller:";
            // 
            // lstPendientes
            // 
            lstPendientes.Font = new Font("Consolas", 10F);
            lstPendientes.FormattingEnabled = true;
            lstPendientes.Location = new Point(12, 40);
            lstPendientes.Name = "lstPendientes";
            lstPendientes.Size = new Size(476, 289);
            lstPendientes.TabIndex = 1;
            // 
            // lblEventos
            // 
            lblEventos.AutoSize = true;
            lblEventos.Location = new Point(12, 340);
            lblEventos.Name = "lblEventos";
            lblEventos.TabIndex = 2;
            lblEventos.Text = "Últimos avisos:";
            // 
            // lstEventos
            // 
            lstEventos.FormattingEnabled = true;
            lstEventos.ItemHeight = 15;
            lstEventos.Location = new Point(12, 360);
            lstEventos.Name = "lstEventos";
            lstEventos.Size = new Size(476, 109);
            lstEventos.TabIndex = 3;
            // 
            // FormTaller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ClientSize = new Size(500, 482);
            Controls.Add(lblPendientes);
            Controls.Add(lstPendientes);
            Controls.Add(lblEventos);
            Controls.Add(lstEventos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormTaller";
            StartPosition = FormStartPosition.WindowsDefaultLocation;
            Text = "Pantalla del taller";
            FormClosed += FormTaller_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPendientes;
        private ListBox lstPendientes;
        private Label lblEventos;
        private ListBox lstEventos;
    }
}
