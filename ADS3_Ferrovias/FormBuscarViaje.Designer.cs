namespace ADS3_Ferrovias
{
    partial class FormBuscarViaje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvViajes = new System.Windows.Forms.DataGridView();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCantidadPasajeros = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadPasajeros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(738, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 38);
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvViajes
            // 
            this.dgvViajes.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.dgvViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViajes.Location = new System.Drawing.Point(15, 112);
            this.dgvViajes.Name = "dgvViajes";
            this.dgvViajes.Size = new System.Drawing.Size(815, 342);
            this.dgvViajes.TabIndex = 25;
            // 
            // cbCategoria
            // 
            this.cbCategoria.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(481, 64);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Categoria";
            // 
            // nudCantidadPasajeros
            // 
            this.nudCantidadPasajeros.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.nudCantidadPasajeros.Location = new System.Drawing.Point(613, 64);
            this.nudCantidadPasajeros.Name = "nudCantidadPasajeros";
            this.nudCantidadPasajeros.Size = new System.Drawing.Size(110, 20);
            this.nudCantidadPasajeros.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cantidad de Pasajeros";
            // 
            // cbDestino
            // 
            this.cbDestino.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(304, 64);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(171, 21);
            this.cbDestino.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Estacion Destino";
            // 
            // cbOrigen
            // 
            this.cbOrigen.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(126, 64);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(171, 21);
            this.cbOrigen.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Estacion Origen";
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.dtpFechaSalida.Location = new System.Drawing.Point(15, 66);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(104, 20);
            this.dtpFechaSalida.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Fecha de salida";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Buscar Viajes";
            // 
            // FormBuscarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 484);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvViajes);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudCantidadPasajeros);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDestino);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbOrigen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaSalida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormBuscarViaje";
            this.Text = "FormBuscarViaje";
            this.Load += new System.EventHandler(this.FormBuscarViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadPasajeros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvViajes;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCantidadPasajeros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}