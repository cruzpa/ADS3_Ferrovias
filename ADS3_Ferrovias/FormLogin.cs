using BLL;
using System;
using System.Windows.Forms;
using Servicios;

namespace ADS3_Ferrovias
{
    public partial class FormLogin : Form
    {
        private MenuPrincipal menuPrincipal;
        private LoginService loginService = new LoginService();

        public FormLogin(MenuPrincipal menu)
        {
            InitializeComponent();
            menuPrincipal = menu;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            loginService.Login(username, password);

            if (SessionManager.GetInstance.usuario != null )
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos. Inténtalo de nuevo.",
                    "Error de inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    }
}
