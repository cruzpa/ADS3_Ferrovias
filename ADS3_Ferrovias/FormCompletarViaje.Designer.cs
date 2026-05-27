namespace ADS3_Ferrovias
{
    partial class FormCompletarViaje
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
            this.lblDetalleViaje = new System.Windows.Forms.Label();
            this.lblResumenViaje = new System.Windows.Forms.Label();
            this.dgvPasajeros = new System.Windows.Forms.DataGridView();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblPasajeros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetalleViaje
            // 
            this.lblDetalleViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetalleViaje.Location = new System.Drawing.Point(20, 20);
            this.lblDetalleViaje.Name = "lblDetalleViaje";
            this.lblDetalleViaje.Size = new System.Drawing.Size(330, 155);
            this.lblDetalleViaje.TabIndex = 0;
            this.lblDetalleViaje.Text = "Detalle del viaje";
            // 
            // lblResumenViaje
            // 
            this.lblResumenViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResumenViaje.Location = new System.Drawing.Point(370, 20);
            this.lblResumenViaje.Name = "lblResumenViaje";
            this.lblResumenViaje.Size = new System.Drawing.Size(410, 155);
            this.lblResumenViaje.TabIndex = 1;
            this.lblResumenViaje.Text = "Resumen";
            // 
            // dgvPasajeros
            // 
            this.dgvPasajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasajeros.Location = new System.Drawing.Point(20, 220);
            this.dgvPasajeros.Name = "dgvPasajeros";
            this.dgvPasajeros.RowHeadersWidth = 51;
            this.dgvPasajeros.RowTemplate.Height = 24;
            this.dgvPasajeros.Size = new System.Drawing.Size(760, 170);
            this.dgvPasajeros.TabIndex = 2;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(670, 406);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(110, 32);
            this.btnComprar.TabIndex = 3;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(554, 406);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 32);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Location = new System.Drawing.Point(20, 198);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(69, 16);
            this.lblPasajeros.TabIndex = 5;
            this.lblPasajeros.Text = "Pasajeros";
            // 
            // FormCompletarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dgvPasajeros);
            this.Controls.Add(this.lblResumenViaje);
            this.Controls.Add(this.lblDetalleViaje);
            this.Name = "FormCompletarViaje";
            this.Text = "FormCompletarViaje";
            this.Load += new System.EventHandler(this.FormCompletarViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetalleViaje;
        private System.Windows.Forms.Label lblResumenViaje;
        private System.Windows.Forms.DataGridView dgvPasajeros;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblPasajeros;
    }
}
