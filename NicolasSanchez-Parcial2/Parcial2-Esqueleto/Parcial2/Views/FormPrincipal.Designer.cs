using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parcial2.Views
{
    partial class FormPrincipal
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
            lblTitulo = new Label();
            dgvOrdenes = new DataGridView();
            lblResumen = new Label();
            btnNuevo = new Button();
            btnAvanzar = new Button();
            btnCancelar = new Button();
            btnComprobante = new Button();
            btnTaller = new Button();
            btnBitacora = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Taller Mecánico Juan B. Justo · Órdenes";
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.Location = new Point(12, 50);
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.Size = new Size(876, 380);
            dgvOrdenes.TabIndex = 1;
            // 
            // lblResumen
            // 
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblResumen.Location = new Point(12, 440);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(876, 23);
            lblResumen.TabIndex = 2;
            lblResumen.Text = "Resumen";
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.Location = new Point(12, 475);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(135, 36);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nueva orden";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAvanzar.Location = new Point(157, 475);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(135, 36);
            btnAvanzar.TabIndex = 4;
            btnAvanzar.Text = "Avanzar estado";
            btnAvanzar.UseVisualStyleBackColor = true;
            btnAvanzar.Click += btnAvanzar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelar.Location = new Point(302, 475);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(135, 36);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar orden";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnComprobante
            // 
            btnComprobante.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnComprobante.Location = new Point(447, 475);
            btnComprobante.Name = "btnComprobante";
            btnComprobante.Size = new Size(135, 36);
            btnComprobante.TabIndex = 6;
            btnComprobante.Text = "Comprobante";
            btnComprobante.UseVisualStyleBackColor = true;
            btnComprobante.Click += btnComprobante_Click;
            // 
            // btnTaller
            // 
            btnTaller.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTaller.Location = new Point(592, 475);
            btnTaller.Name = "btnTaller";
            btnTaller.Size = new Size(135, 36);
            btnTaller.TabIndex = 7;
            btnTaller.Text = "Pantalla taller";
            btnTaller.UseVisualStyleBackColor = true;
            btnTaller.Click += btnTaller_Click;
            // 
            // btnBitacora
            // 
            btnBitacora.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBitacora.Location = new Point(737, 475);
            btnBitacora.Name = "btnBitacora";
            btnBitacora.Size = new Size(135, 36);
            btnBitacora.TabIndex = 8;
            btnBitacora.Text = "Bitácora";
            btnBitacora.UseVisualStyleBackColor = true;
            btnBitacora.Click += btnBitacora_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ClientSize = new Size(900, 525);
            Controls.Add(lblTitulo);
            Controls.Add(dgvOrdenes);
            Controls.Add(lblResumen);
            Controls.Add(btnNuevo);
            Controls.Add(btnAvanzar);
            Controls.Add(btnCancelar);
            Controls.Add(btnComprobante);
            Controls.Add(btnTaller);
            Controls.Add(btnBitacora);
            MinimumSize = new Size(916, 400);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Taller JBJ — Órdenes de trabajo";
            Load += FormPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvOrdenes;
        private Label lblResumen;
        private Button btnNuevo;
        private Button btnAvanzar;
        private Button btnCancelar;
        private Button btnComprobante;
        private Button btnTaller;
        private Button btnBitacora;
    }
}
