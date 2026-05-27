using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace ADS3_Ferrovias
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            InicializarLogin();
        }

        private void InicializarLogin()
        {
            menuStrip1.Visible = false;

            FormLogin login = CrearLogin();
            CentrarFormulario(login);

            login.FormClosed += Login_FormClosed;
            login.Show();
        }

        private FormLogin CrearLogin()
        {
            FormLogin login = new FormLogin(this);

            login.MdiParent = this;
            login.FormBorderStyle = FormBorderStyle.None;
            login.ControlBox = false;
            login.MinimizeBox = false;
            login.MaximizeBox = false;
            login.ShowIcon = false;
            login.ShowInTaskbar = false;
            login.StartPosition = FormStartPosition.Manual;

            return login;
        }

        private void CentrarFormulario(Form formulario)
        {
            formulario.Left = (this.ClientSize.Width - formulario.Width) / 2;
            formulario.Top = (this.ClientSize.Height - formulario.Height) / 2;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool usuarioLogueado = SessionManager.GetInstance.usuario != null;

            menuStrip1.Visible = usuarioLogueado;

            if (usuarioLogueado)
            {
                AbrirBuscarViaje();
            }
        }

        private void AbrirBuscarViaje()
        {
            FormBuscarViaje formBuscarViaje = new FormBuscarViaje();

            formBuscarViaje.MdiParent = this;
            formBuscarViaje.StartPosition = FormStartPosition.Manual;
            CentrarFormulario(formBuscarViaje);
            formBuscarViaje.Show();
        }

        public void AbrirCompletarViaje(ViajeResultadoBusqueda viajeSeleccionado, int cantidadPasajeros)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario is FormBuscarViaje)
                {
                    formulario.Hide();
                }
            }

            FormCompletarViaje formCompletarViaje = new FormCompletarViaje(viajeSeleccionado, cantidadPasajeros);

            formCompletarViaje.MdiParent = this;
            formCompletarViaje.StartPosition = FormStartPosition.Manual;
            CentrarFormulario(formCompletarViaje);
            formCompletarViaje.Show();
        }

        public void MostrarBuscarViaje()
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario is FormBuscarViaje)
                {
                    formulario.Show();
                    CentrarFormulario(formulario);
                    formulario.BringToFront();
                    return;
                }
            }

            AbrirBuscarViaje();
        }

        public void AbrirComprarViaje(string detalleCompra, List<PasajeroCompraDetalle> pasajeros, decimal precioTotal)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario is FormCompletarViaje)
                {
                    formulario.Hide();
                }
            }

            FormComprarViaje formComprarViaje = new FormComprarViaje(detalleCompra, pasajeros, precioTotal);

            formComprarViaje.MdiParent = this;
            formComprarViaje.StartPosition = FormStartPosition.Manual;
            CentrarFormulario(formComprarViaje);
            formComprarViaje.Show();
        }

        public void MostrarCompletarViaje()
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario is FormCompletarViaje)
                {
                    formulario.Show();
                    CentrarFormulario(formulario);
                    formulario.BringToFront();
                    return;
                }
            }
        }

        public void LimpiarMenuPrincipal()
        {
            foreach (Form formulario in this.MdiChildren)
            {
                formulario.Close();
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager.GetInstance.usuario != null)
            {
                SessionManager.Logout();
            }

            foreach (Form formulario in this.MdiChildren)
            {
                formulario.Close();
            }

            InicializarLogin();
        }

        private void buscarViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                formulario.Close();
            }

            AbrirBuscarViaje();
        }
    }
}
