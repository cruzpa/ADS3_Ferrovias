namespace ADS3_Ferrovias
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verPasajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maquinistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoDeGestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarViajeToolStripMenuItem,
            this.verPasajesToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.infoDeGestionToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1267, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verPasajesToolStripMenuItem
            // 
            this.verPasajesToolStripMenuItem.Name = "verPasajesToolStripMenuItem";
            this.verPasajesToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.verPasajesToolStripMenuItem.Text = "VerPasajes";
            this.verPasajesToolStripMenuItem.Click += new System.EventHandler(this.verPasajesToolStripMenuItem_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.maquinistaToolStripMenuItem,
            this.estacionToolStripMenuItem,
            this.formacionesToolStripMenuItem,
            this.viajesToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.aBMToolStripMenuItem.Text = "ABMs";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.usuarioToolStripMenuItem.Text = "Cliente";
            // 
            // maquinistaToolStripMenuItem
            // 
            this.maquinistaToolStripMenuItem.Name = "maquinistaToolStripMenuItem";
            this.maquinistaToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.maquinistaToolStripMenuItem.Text = "Maquinista";
            // 
            // estacionToolStripMenuItem
            // 
            this.estacionToolStripMenuItem.Name = "estacionToolStripMenuItem";
            this.estacionToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.estacionToolStripMenuItem.Text = "Estacion, Tramos y Recorridos";
            // 
            // formacionesToolStripMenuItem
            // 
            this.formacionesToolStripMenuItem.Name = "formacionesToolStripMenuItem";
            this.formacionesToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.formacionesToolStripMenuItem.Text = "Formaciones";
            // 
            // viajesToolStripMenuItem
            // 
            this.viajesToolStripMenuItem.Name = "viajesToolStripMenuItem";
            this.viajesToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.viajesToolStripMenuItem.Text = "Viajes";
            // 
            // infoDeGestionToolStripMenuItem
            // 
            this.infoDeGestionToolStripMenuItem.Name = "infoDeGestionToolStripMenuItem";
            this.infoDeGestionToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.infoDeGestionToolStripMenuItem.Text = "Info de Gestion";
            this.infoDeGestionToolStripMenuItem.Click += new System.EventHandler(this.infoDeGestionToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.cerrarSesionToolStripMenuItem.Text = "CerrarSesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // buscarViajeToolStripMenuItem
            // 
            this.buscarViajeToolStripMenuItem.Name = "buscarViajeToolStripMenuItem";
            this.buscarViajeToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.buscarViajeToolStripMenuItem.Text = "BuscarViaje";
            this.buscarViajeToolStripMenuItem.Click += new System.EventHandler(this.buscarViajeToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 684);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maquinistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoDeGestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPasajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarViajeToolStripMenuItem;
    }
}

