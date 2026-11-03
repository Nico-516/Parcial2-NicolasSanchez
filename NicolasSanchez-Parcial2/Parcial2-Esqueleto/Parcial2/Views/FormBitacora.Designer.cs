using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parcial2.Views
{
    partial class FormBitacora
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
            lstEntradas = new ListBox();
            SuspendLayout();
            // 
            // lstEntradas
            // 
            lstEntradas.Dock = DockStyle.Fill;
            lstEntradas.Font = new Font("Consolas", 9.75F);
            lstEntradas.FormattingEnabled = true;
            lstEntradas.Location = new Point(0, 0);
            lstEntradas.Name = "lstEntradas";
            lstEntradas.Size = new Size(640, 400);
            lstEntradas.TabIndex = 0;
            // 
            // FormBitacora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ClientSize = new Size(640, 400);
            Controls.Add(lstEntradas);
            Name = "FormBitacora";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bitácora de la sesión";
            Load += FormBitacora_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstEntradas;
    }
}
