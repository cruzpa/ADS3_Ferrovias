namespace ADS3_Ferrovias
{
    partial class FormReportes
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
            this.lblTitulo.Location = new System.Drawing.Point(15, 16);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(75, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes";
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Location = new System.Drawing.Point(16, 57);
            this.lblTipoReporte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.Size = new System.Drawing.Size(79, 13);
            this.lblTipoReporte.TabIndex = 1;
            this.lblTipoReporte.Text = "Tipo de reporte";
            // 
            // cbTipoReporte
            // 
            this.cbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoReporte.FormattingEnabled = true;
            this.cbTipoReporte.Location = new System.Drawing.Point(19, 75);
            this.cbTipoReporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTipoReporte.Name = "cbTipoReporte";
            this.cbTipoReporte.Size = new System.Drawing.Size(196, 21);
            this.cbTipoReporte.TabIndex = 2;
            this.cbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cbTipoReporte_SelectedIndexChanged);
            // 
            // lblViaje
            // 
            this.lblViaje.AutoSize = true;
            this.lblViaje.Location = new System.Drawing.Point(236, 57);
            this.lblViaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblViaje.Name = "lblViaje";
            this.lblViaje.Size = new System.Drawing.Size(30, 13);
            this.lblViaje.TabIndex = 3;
            this.lblViaje.Text = "Viaje";
            // 
            // cbViaje
            // 
            this.cbViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViaje.FormattingEnabled = true;
            this.cbViaje.Location = new System.Drawing.Point(238, 75);
            this.cbViaje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbViaje.Name = "cbViaje";
            this.cbViaje.Size = new System.Drawing.Size(121, 21);
            this.cbViaje.TabIndex = 4;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(382, 72);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(90, 26);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultado.Location = new System.Drawing.Point(19, 118);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(567, 45);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "Resultado";
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(19, 179);
            this.dgvResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.RowHeadersWidth = 51;
            this.dgvResultado.RowTemplate.Height = 24;
            this.dgvResultado.Size = new System.Drawing.Size(566, 167);
            this.dgvResultado.TabIndex = 7;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cbViaje);
            this.Controls.Add(this.lblViaje);
            this.Controls.Add(this.cbTipoReporte);
            this.Controls.Add(this.lblTipoReporte);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
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
