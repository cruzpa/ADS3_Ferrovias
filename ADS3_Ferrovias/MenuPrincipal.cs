using System;
using System.Windows.Forms;
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
    }
}
