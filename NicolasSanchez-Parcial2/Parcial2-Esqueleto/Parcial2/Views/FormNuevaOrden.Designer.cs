using System.Drawing;
using System.Windows.Forms;

namespace Parcial2.Views
{
    partial class FormNuevaOrden
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
            lblCliente = new Label();
            txtCliente = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblPatente = new Label();
            txtPatente = new TextBox();
            lblPago = new Label();
            cmbPago = new ComboBox();
            lblCuotas = new Label();
            nudCuotas = new NumericUpDown();
            lblCuit = new Label();
            txtCuit = new TextBox();
            lblServicio = new Label();
            cmbServicio = new ComboBox();
            nudCantidad = new NumericUpDown();
            btnAgregar = new Button();
            lstItems = new ListBox();
            lblSubtotal = new Label();
            lblAjuste = new Label();
            lblTotal = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCuotas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(20, 23);
            lblCliente.Name = "lblCliente";
            lblCliente.Text = "Cliente:";
            lblCliente.TabIndex = 0;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(140, 20);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(260, 23);
            txtCliente.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 58);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Text = "Teléfono:";
            lblTelefono.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(140, 55);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(260, 23);
            txtTelefono.TabIndex = 3;
            // 
            // lblPatente
            // 
            lblPatente.AutoSize = true;
            lblPatente.Location = new Point(20, 93);
            lblPatente.Name = "lblPatente";
            lblPatente.Text = "Patente:";
            lblPatente.TabIndex = 4;
            // 
            // txtPatente
            // 
            txtPatente.Location = new Point(140, 90);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(120, 23);
            txtPatente.CharacterCasing = CharacterCasing.Upper;
            txtPatente.MaxLength = 9;
            txtPatente.TabIndex = 5;
            // 
            // lblPago
            // 
            lblPago.AutoSize = true;
            lblPago.Location = new Point(20, 128);
            lblPago.Name = "lblPago";
            lblPago.Text = "Forma de pago:";
            lblPago.TabIndex = 6;
            // 
            // cmbPago
            // 
            cmbPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPago.Location = new Point(140, 125);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(260, 23);
            cmbPago.SelectedIndexChanged += cmbPago_SelectedIndexChanged;
            cmbPago.TabIndex = 7;
            // 
            // lblCuotas
            // 
            lblCuotas.AutoSize = true;
            lblCuotas.Location = new Point(20, 163);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Text = "Cuotas:";
            lblCuotas.TabIndex = 8;
            // 
            // nudCuotas
            // 
            nudCuotas.Location = new Point(140, 160);
            nudCuotas.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudCuotas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCuotas.Name = "nudCuotas";
            nudCuotas.Size = new Size(60, 23);
            nudCuotas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCuotas.ValueChanged += nudCuotas_ValueChanged;
            nudCuotas.TabIndex = 9;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(20, 198);
            lblCuit.Name = "lblCuit";
            lblCuit.Text = "CUIT:";
            lblCuit.TabIndex = 10;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(140, 195);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(160, 23);
            txtCuit.TabIndex = 11;
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Location = new Point(20, 248);
            lblServicio.Name = "lblServicio";
            lblServicio.Text = "Catálogo:";
            lblServicio.TabIndex = 12;
            // 
            // cmbServicio
            // 
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Location = new Point(140, 245);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(280, 23);
            cmbServicio.TabIndex = 13;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(430, 245);
            nudCantidad.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(60, 23);
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.TabIndex = 14;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(500, 243);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 27);
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            btnAgregar.TabIndex = 15;
            // 
            // lstItems
            // 
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 15;
            lstItems.Location = new Point(20, 280);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(570, 154);
            lstItems.TabIndex = 16;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Location = new Point(240, 445);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(350, 20);
            lblSubtotal.Text = "Subtotal:";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            lblSubtotal.TabIndex = 17;
            // 
            // lblAjuste
            // 
            lblAjuste.Location = new Point(140, 468);
            lblAjuste.Name = "lblAjuste";
            lblAjuste.Size = new Size(450, 20);
            lblAjuste.Text = "Ajuste:";
            lblAjuste.TextAlign = ContentAlignment.MiddleRight;
            lblAjuste.TabIndex = 18;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.Location = new Point(240, 491);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(350, 24);
            lblTotal.Text = "TOTAL:";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.TabIndex = 19;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(340, 530);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(120, 34);
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            btnConfirmar.TabIndex = 20;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(470, 530);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 34);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.TabIndex = 21;
            // 
            // FormNuevaOrden
            // 
            AcceptButton = btnConfirmar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CancelButton = btnCancelar;
            ClientSize = new Size(610, 580);
            Controls.Add(lblCliente);
            Controls.Add(txtCliente);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblPatente);
            Controls.Add(txtPatente);
            Controls.Add(lblPago);
            Controls.Add(cmbPago);
            Controls.Add(lblCuotas);
            Controls.Add(nudCuotas);
            Controls.Add(lblCuit);
            Controls.Add(txtCuit);
            Controls.Add(lblServicio);
            Controls.Add(cmbServicio);
            Controls.Add(nudCantidad);
            Controls.Add(btnAgregar);
            Controls.Add(lstItems);
            Controls.Add(lblSubtotal);
            Controls.Add(lblAjuste);
            Controls.Add(lblTotal);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNuevaOrden";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva orden de trabajo";
            ((System.ComponentModel.ISupportInitialize)nudCuotas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private TextBox txtCliente;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblPatente;
        private TextBox txtPatente;
        private Label lblPago;
        private ComboBox cmbPago;
        private Label lblCuotas;
        private NumericUpDown nudCuotas;
        private Label lblCuit;
        private TextBox txtCuit;
        private Label lblServicio;
        private ComboBox cmbServicio;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private ListBox lstItems;
        private Label lblSubtotal;
        private Label lblAjuste;
        private Label lblTotal;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}
