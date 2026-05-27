namespace ADS3_Ferrovias
{
    partial class FormPasaje
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
            this.dgvPasajes = new System.Windows.Forms.DataGridView();
            this.lblDetallePasaje = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPasajes
            // 
            this.dgvPasajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasajes.Location = new System.Drawing.Point(20, 55);
            this.dgvPasajes.Name = "dgvPasajes";
            this.dgvPasajes.RowHeadersWidth = 51;
            this.dgvPasajes.RowTemplate.Height = 24;
            this.dgvPasajes.Size = new System.Drawing.Size(760, 190);
            this.dgvPasajes.TabIndex = 0;
            // 
            // lblDetallePasaje
            // 
            this.lblDetallePasaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetallePasaje.Location = new System.Drawing.Point(20, 265);
            this.lblDetallePasaje.Name = "lblDetallePasaje";
            this.lblDetallePasaje.Size = new System.Drawing.Size(585, 165);
            this.lblDetallePasaje.TabIndex = 1;
            this.lblDetallePasaje.Text = "Detalle del pasaje";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(630, 398);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 32);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar pasaje";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(113, 25);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Mis pasajes";
            // 
            // FormPasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblDetallePasaje);
            this.Controls.Add(this.dgvPasajes);
            this.Name = "FormPasaje";
            this.Text = "FormPasaje";
            this.Load += new System.EventHandler(this.FormPasaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPasajes;
        private System.Windows.Forms.Label lblDetallePasaje;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
