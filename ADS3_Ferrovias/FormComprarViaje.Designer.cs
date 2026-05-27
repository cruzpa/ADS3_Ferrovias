namespace ADS3_Ferrovias
{
    partial class FormComprarViaje
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDetalleCompra = new System.Windows.Forms.Label();
            this.dgvPasajeros = new System.Windows.Forms.DataGridView();
            this.lblMedioPago = new System.Windows.Forms.Label();
            this.cbMediosDePago = new System.Windows.Forms.ComboBox();
            this.chkConfirmar = new System.Windows.Forms.CheckBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConfirmarCompra = new System.Windows.Forms.Button();
            this.lblPasajeros = new System.Windows.Forms.Label();
            this.pnlDetalleCompra = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).BeginInit();
            this.pnlDetalleCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDetalleCompra
            // 
            this.lblDetalleCompra.AutoSize = true;
            this.lblDetalleCompra.Location = new System.Drawing.Point(8, 8);
            this.lblDetalleCompra.Name = "lblDetalleCompra";
            this.lblDetalleCompra.Size = new System.Drawing.Size(118, 16);
            this.lblDetalleCompra.TabIndex = 0;
            this.lblDetalleCompra.Text = "Detalle de compra";
            // 
            // dgvPasajeros
            // 
            this.dgvPasajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasajeros.Location = new System.Drawing.Point(20, 247);
            this.dgvPasajeros.Name = "dgvPasajeros";
            this.dgvPasajeros.RowHeadersWidth = 51;
            this.dgvPasajeros.RowTemplate.Height = 24;
            this.dgvPasajeros.Size = new System.Drawing.Size(760, 244);
            this.dgvPasajeros.TabIndex = 1;
            // 
            // lblMedioPago
            // 
            this.lblMedioPago.AutoSize = true;
            this.lblMedioPago.Location = new System.Drawing.Point(17, 501);
            this.lblMedioPago.Name = "lblMedioPago";
            this.lblMedioPago.Size = new System.Drawing.Size(99, 16);
            this.lblMedioPago.TabIndex = 2;
            this.lblMedioPago.Text = "Medio de pago";
            // 
            // cbMediosDePago
            // 
            this.cbMediosDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMediosDePago.FormattingEnabled = true;
            this.cbMediosDePago.Location = new System.Drawing.Point(127, 497);
            this.cbMediosDePago.Name = "cbMediosDePago";
            this.cbMediosDePago.Size = new System.Drawing.Size(210, 24);
            this.cbMediosDePago.TabIndex = 3;
            // 
            // chkConfirmar
            // 
            this.chkConfirmar.AutoSize = true;
            this.chkConfirmar.Location = new System.Drawing.Point(17, 548);
            this.chkConfirmar.Name = "chkConfirmar";
            this.chkConfirmar.Size = new System.Drawing.Size(250, 20);
            this.chkConfirmar.TabIndex = 4;
            this.chkConfirmar.Text = "Confirmo que los datos son correctos";
            this.chkConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(542, 541);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 32);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConfirmarCompra
            // 
            this.btnConfirmarCompra.Location = new System.Drawing.Point(667, 541);
            this.btnConfirmarCompra.Name = "btnConfirmarCompra";
            this.btnConfirmarCompra.Size = new System.Drawing.Size(110, 32);
            this.btnConfirmarCompra.TabIndex = 6;
            this.btnConfirmarCompra.Text = "Comprar";
            this.btnConfirmarCompra.UseVisualStyleBackColor = true;
            this.btnConfirmarCompra.Click += new System.EventHandler(this.btnConfirmarCompra_Click);
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Location = new System.Drawing.Point(17, 228);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(69, 16);
            this.lblPasajeros.TabIndex = 7;
            this.lblPasajeros.Text = "Pasajeros";
            // 
            // pnlDetalleCompra
            // 
            this.pnlDetalleCompra.AutoScroll = true;
            this.pnlDetalleCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalleCompra.Controls.Add(this.lblDetalleCompra);
            this.pnlDetalleCompra.Location = new System.Drawing.Point(20, 20);
            this.pnlDetalleCompra.Name = "pnlDetalleCompra";
            this.pnlDetalleCompra.Size = new System.Drawing.Size(760, 184);
            this.pnlDetalleCompra.TabIndex = 8;
            // 
            // FormComprarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 598);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.btnConfirmarCompra);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.chkConfirmar);
            this.Controls.Add(this.cbMediosDePago);
            this.Controls.Add(this.lblMedioPago);
            this.Controls.Add(this.dgvPasajeros);
            this.Controls.Add(this.pnlDetalleCompra);
            this.Name = "FormComprarViaje";
            this.Text = "FormComprarViaje";
            this.Load += new System.EventHandler(this.FormComprarViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).EndInit();
            this.pnlDetalleCompra.ResumeLayout(false);
            this.pnlDetalleCompra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetalleCompra;
        private System.Windows.Forms.DataGridView dgvPasajeros;
        private System.Windows.Forms.Label lblMedioPago;
        private System.Windows.Forms.ComboBox cbMediosDePago;
        private System.Windows.Forms.CheckBox chkConfirmar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConfirmarCompra;
        private System.Windows.Forms.Label lblPasajeros;
        private System.Windows.Forms.Panel pnlDetalleCompra;
    }
}
