namespace ADS3_Ferrovias
{
    partial class FormInfoGestion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTipoReporte = new System.Windows.Forms.Label();
            this.cbTipoReporte = new System.Windows.Forms.ComboBox();
            this.lblViaje = new System.Windows.Forms.Label();
            this.cbViaje = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(157, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Info de Gestion";
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Location = new System.Drawing.Point(22, 70);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.Size = new System.Drawing.Size(101, 16);
            this.lblTipoReporte.TabIndex = 1;
            this.lblTipoReporte.Text = "Tipo de reporte";
            // 
            // cbTipoReporte
            // 
            this.cbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoReporte.FormattingEnabled = true;
            this.cbTipoReporte.Location = new System.Drawing.Point(25, 92);
            this.cbTipoReporte.Name = "cbTipoReporte";
            this.cbTipoReporte.Size = new System.Drawing.Size(260, 24);
            this.cbTipoReporte.TabIndex = 2;
            this.cbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cbTipoReporte_SelectedIndexChanged);
            // 
            // lblViaje
            // 
            this.lblViaje.AutoSize = true;
            this.lblViaje.Location = new System.Drawing.Point(315, 70);
            this.lblViaje.Name = "lblViaje";
            this.lblViaje.Size = new System.Drawing.Size(37, 16);
            this.lblViaje.TabIndex = 3;
            this.lblViaje.Text = "Viaje";
            // 
            // cbViaje
            // 
            this.cbViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViaje.FormattingEnabled = true;
            this.cbViaje.Location = new System.Drawing.Point(318, 92);
            this.cbViaje.Name = "cbViaje";
            this.cbViaje.Size = new System.Drawing.Size(160, 24);
            this.cbViaje.TabIndex = 4;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(510, 88);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 32);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Location = new System.Drawing.Point(25, 145);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(755, 55);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "Resultado";
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(25, 220);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.RowHeadersWidth = 51;
            this.dgvResultado.RowTemplate.Height = 24;
            this.dgvResultado.Size = new System.Drawing.Size(755, 205);
            this.dgvResultado.TabIndex = 7;
            // 
            // FormInfoGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cbViaje);
            this.Controls.Add(this.lblViaje);
            this.Controls.Add(this.cbTipoReporte);
            this.Controls.Add(this.lblTipoReporte);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormInfoGestion";
            this.Text = "FormInfoGestion";
            this.Load += new System.EventHandler(this.FormInfoGestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.ComboBox cbTipoReporte;
        private System.Windows.Forms.Label lblViaje;
        private System.Windows.Forms.ComboBox cbViaje;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvResultado;
    }
}
