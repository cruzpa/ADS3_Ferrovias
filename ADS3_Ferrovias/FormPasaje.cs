using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;

namespace ADS3_Ferrovias
{
    public partial class FormPasaje : Form
    {
        private readonly PasajeService pasajeService = new PasajeService();
        private List<PasajeListado> pasajes = new List<PasajeListado>();

        public FormPasaje()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void FormPasaje_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarPasajes();
        }

        private void ConfigurarGrilla()
        {
            dgvPasajes.AutoGenerateColumns = false;
            dgvPasajes.AllowUserToAddRows = false;
            dgvPasajes.AllowUserToDeleteRows = false;
            dgvPasajes.AllowUserToResizeRows = false;
            dgvPasajes.ReadOnly = true;
            dgvPasajes.RowHeadersVisible = false;
            dgvPasajes.MultiSelect = false;
            dgvPasajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajes.Columns.Clear();

            dgvPasajes.Columns.Add(CrearColumnaTexto("Numero", "Nro"));
            dgvPasajes.Columns.Add(CrearColumnaTexto("FechaViaje", "Fecha"));
            dgvPasajes.Columns.Add(CrearColumnaTexto("HoraViaje", "Hora"));
            dgvPasajes.Columns.Add(CrearColumnaTexto("Origen", "Origen"));
            dgvPasajes.Columns.Add(CrearColumnaTexto("Destino", "Destino"));
            dgvPasajes.Columns.Add(CrearColumnaTexto("Asiento", "Asiento"));
            dgvPasajes.Columns.Add(CrearColumnaTexto("Estado", "Estado"));

            dgvPasajes.SelectionChanged += dgvPasajes_SelectionChanged;
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

        private void CargarPasajes()
        {
            Usuario usuario = SessionManager.GetInstance.usuario;

            if (usuario == null)
            {
                pasajes = new List<PasajeListado>();
            }
            else
            {
                pasajes = pasajeService.ListarPorCliente(usuario.Username)
                    .Select(CrearPasajeListado)
                    .ToList();
            }

            dgvPasajes.DataSource = null;
            dgvPasajes.DataSource = pasajes;

            if (pasajes.Any())
            {
                dgvPasajes.Rows[0].Selected = true;
                MostrarDetalle(pasajes[0]);
            }
            else
            {
                lblDetallePasaje.Text = "Detalle del pasaje\n\nNo hay pasajes para mostrar.";
                btnCancelar.Enabled = false;
            }
        }

        private PasajeListado CrearPasajeListado(Pasaje pasaje)
        {
            return new PasajeListado
            {
                Pasaje = pasaje,
                Numero = pasaje.Numero,
                FechaViaje = pasaje.Viaje.FechaHoraSalida.ToString("dd/MM/yyyy"),
                HoraViaje = pasaje.Viaje.FechaHoraSalida.ToString("HH:mm"),
                Origen = pasaje.Origen.Nombre,
                Destino = pasaje.Destino.Nombre,
                Asiento = "V" + pasaje.Vagon.Numero + " - " + pasaje.Butaca.Numero,
                Estado = pasaje.Cancelado ? "Cancelado" : "Activo"
            };
        }

        private void dgvPasajes_SelectionChanged(object sender, EventArgs e)
        {
            PasajeListado pasajeSeleccionado = ObtenerPasajeSeleccionado();

            if (pasajeSeleccionado != null)
            {
                MostrarDetalle(pasajeSeleccionado);
            }
        }

        private PasajeListado ObtenerPasajeSeleccionado()
        {
            if (dgvPasajes.CurrentRow == null)
            {
                return null;
            }

            return dgvPasajes.CurrentRow.DataBoundItem as PasajeListado;
        }

        private void MostrarDetalle(PasajeListado pasajeListado)
        {
            Pasaje pasaje = pasajeListado.Pasaje;

            lblDetallePasaje.Text =
                "Detalle del pasaje\n\n" +
                "Numero: " + pasaje.Numero + "\n" +
                "Pasajero: " + pasaje.Pasajero.Nombre + " " + pasaje.Pasajero.Apellido + "\n" +
                "DNI: " + pasaje.Pasajero.Dni + "\n" +
                "Origen: " + pasaje.Origen.Nombre + "\n" +
                "Destino: " + pasaje.Destino.Nombre + "\n" +
                "Fecha viaje: " + pasaje.Viaje.FechaHoraSalida.ToString("dd/MM/yyyy HH:mm") + "\n" +
                "Asiento: V" + pasaje.Vagon.Numero + " - " + pasaje.Butaca.Numero + "\n" +
                "Categoria: " + pasaje.Vagon.Categoria + "\n" +
                "Precio: $" + pasaje.CostoTotal.ToString("0.00") + "\n" +
                "Emitido: " + pasaje.FechaEmision.ToString("dd/MM/yyyy HH:mm") + "\n" +
                "Estado: " + pasajeListado.Estado;

            btnCancelar.Enabled = !pasaje.Cancelado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PasajeListado pasajeSeleccionado = ObtenerPasajeSeleccionado();

            if (pasajeSeleccionado == null)
            {
                MessageBox.Show("Seleccione un pasaje para cancelar.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "Desea cancelar el pasaje seleccionado?",
                "Cancelar pasaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                pasajeService.Cancelar(pasajeSeleccionado.Pasaje);
                MessageBox.Show("Pasaje cancelado correctamente.");
                CargarPasajes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo cancelar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private class PasajeListado
        {
            public Pasaje Pasaje { get; set; }
            public int Numero { get; set; }
            public string FechaViaje { get; set; }
            public string HoraViaje { get; set; }
            public string Origen { get; set; }
            public string Destino { get; set; }
            public string Asiento { get; set; }
            public string Estado { get; set; }
        }
    }
}
