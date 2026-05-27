using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;

namespace ADS3_Ferrovias
{
    public partial class FormComprarViaje : Form
    {
        private readonly string detalleCompra;
        private readonly List<PasajeroCompraDetalle> pasajeros;
        private readonly decimal precioTotal;

        public FormComprarViaje()
            : this(null, new List<PasajeroCompraDetalle>(), 0)
        {
        }

        public FormComprarViaje(string detalleCompra, List<PasajeroCompraDetalle> pasajeros, decimal precioTotal)
        {
            InitializeComponent();

            this.detalleCompra = detalleCompra;
            this.pasajeros = pasajeros ?? new List<PasajeroCompraDetalle>();
            this.precioTotal = precioTotal;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void FormComprarViaje_Load(object sender, EventArgs e)
        {
            cbMediosDePago.DataSource = Enum.GetValues(typeof(MedioPago));
            ConfigurarGrillaPasajeros();
            CargarDetalleCompra();
            dgvPasajeros.DataSource = pasajeros;
        }

        private void ConfigurarGrillaPasajeros()
        {
            dgvPasajeros.AutoGenerateColumns = false;
            dgvPasajeros.AllowUserToAddRows = false;
            dgvPasajeros.AllowUserToDeleteRows = false;
            dgvPasajeros.AllowUserToResizeRows = false;
            dgvPasajeros.ReadOnly = true;
            dgvPasajeros.RowHeadersVisible = false;
            dgvPasajeros.MultiSelect = false;
            dgvPasajeros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajeros.Columns.Clear();

            dgvPasajeros.Columns.Add(CrearColumnaTexto("Nombre", "Nombre"));
            dgvPasajeros.Columns.Add(CrearColumnaTexto("Apellido", "Apellido"));
            dgvPasajeros.Columns.Add(CrearColumnaTexto("Dni", "DNI"));
            dgvPasajeros.Columns.Add(CrearColumnaTexto("FechaNacimiento", "Nacimiento"));
            dgvPasajeros.Columns.Add(CrearColumnaTexto("Asiento", "Asiento"));
            dgvPasajeros.Columns.Add(CrearColumnaTexto("Responsable", "Responsable"));
            dgvPasajeros.Columns.Add(CrearColumnaTexto("Parentesco", "Parentesco"));
        }

        private DataGridViewTextBoxColumn CrearColumnaTexto(string nombre, string titulo)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = nombre,
                HeaderText = titulo,
                DataPropertyName = nombre
            };
        }

        private void CargarDetalleCompra()
        {
            lblDetalleCompra.Text = string.IsNullOrWhiteSpace(detalleCompra)
                ? "Detalle de compra\n\nNo hay datos de compra cargados."
                : detalleCompra + "\nPrecio total del viaje: $" + precioTotal.ToString("0.00");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = this.MdiParent as MenuPrincipal;

            Close();

            if (menuPrincipal != null)
            {
                menuPrincipal.MostrarCompletarViaje();
            }
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            if (!chkConfirmar.Checked)
            {
                MessageBox.Show("Debe confirmar que los datos son correctos.");
                return;
            }

            MessageBox.Show(ObtenerMensajeCompra(), "Compra confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MenuPrincipal menuPrincipal = this.MdiParent as MenuPrincipal;

            if (menuPrincipal != null)
            {
                menuPrincipal.LimpiarMenuPrincipal();
            }
            else
            {
                Close();
            }
        }

        private string ObtenerMensajeCompra()
        {
            string medioPago = Convert.ToString(cbMediosDePago.SelectedItem);

            return
                "Pasaje comprado correctamente.\n\n" +
                detalleCompra + "\n\n" +
                "Medio de pago: " + medioPago + "\n" +
                "Cantidad de pasajeros: " + pasajeros.Count;
        }
    }
}
