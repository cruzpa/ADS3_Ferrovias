using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ADS3_Ferrovias
{
    public partial class FormInfoGestion : Form
    {
        private readonly GestionService gestionService = new GestionService();
        private readonly ViajeService viajeService = new ViajeService();

        public FormInfoGestion()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void FormInfoGestion_Load(object sender, EventArgs e)
        {
            CargarTiposReporte();
            CargarViajes();
            ConfigurarGrilla();
            ActualizarDisponibilidadFiltros();
        }

        private void CargarTiposReporte()
        {
            cbTipoReporte.Items.Clear();
            cbTipoReporte.Items.Add("Recaudacion total");
            cbTipoReporte.Items.Add("Recaudacion por ruta");
            cbTipoReporte.Items.Add("Recaudacion por categoria");
            cbTipoReporte.Items.Add("Pasajeros por viaje");
            cbTipoReporte.Items.Add("Pasajeros por ruta");
            cbTipoReporte.Items.Add("Pasajeros por categoria");
            cbTipoReporte.SelectedIndex = 0;
        }

        private void CargarViajes()
        {
            List<Viaje> viajes = viajeService.Listar();

            cbViaje.DataSource = viajes;
            cbViaje.DisplayMember = "Numero";
        }

        private void ConfigurarGrilla()
        {
            dgvResultado.AllowUserToAddRows = false;
            dgvResultado.AllowUserToDeleteRows = false;
            dgvResultado.AllowUserToResizeRows = false;
            dgvResultado.ReadOnly = true;
            dgvResultado.RowHeadersVisible = false;
            dgvResultado.MultiSelect = false;
            dgvResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDisponibilidadFiltros();
        }

        private void ActualizarDisponibilidadFiltros()
        {
            string tipoReporte = Convert.ToString(cbTipoReporte.SelectedItem);
            bool requiereViaje = tipoReporte == "Pasajeros por viaje";

            lblViaje.Enabled = requiereViaje;
            cbViaje.Enabled = requiereViaje;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string tipoReporte = Convert.ToString(cbTipoReporte.SelectedItem);

            if (string.IsNullOrWhiteSpace(tipoReporte))
            {
                MessageBox.Show("Seleccione un tipo de reporte.");
                return;
            }

            EjecutarReporte(tipoReporte);
        }

        private void EjecutarReporte(string tipoReporte)
        {
            dgvResultado.DataSource = null;

            if (tipoReporte == "Recaudacion total")
            {
                decimal total = gestionService.ObtenerRecaudacionTotal();
                lblResultado.Text = "Recaudacion total: $" + total.ToString("0.00");
                dgvResultado.DataSource = new[]
                {
                    new { Concepto = "Recaudacion total", Importe = total }
                };
                return;
            }

            if (tipoReporte == "Recaudacion por ruta")
            {
                List<RecaudacionPorRuta> resultado = gestionService.ObtenerRecaudacionPorRuta();
                lblResultado.Text = "Rutas informadas: " + resultado.Count;
                dgvResultado.DataSource = resultado;
                return;
            }

            if (tipoReporte == "Recaudacion por categoria")
            {
                List<RecaudacionPorCategoria> resultado = gestionService.ObtenerRecaudacionPorCategoria();
                lblResultado.Text = "Categorias informadas: " + resultado.Count;
                dgvResultado.DataSource = resultado;
                return;
            }

            if (tipoReporte == "Pasajeros por viaje")
            {
                Viaje viaje = cbViaje.SelectedItem as Viaje;
                int cantidad = gestionService.ObtenerCantidadPasajerosPorViaje(viaje);
                lblResultado.Text = "Pasajeros del viaje " + viaje.Numero + ": " + cantidad;
                dgvResultado.DataSource = new[]
                {
                    new
                    {
                        Viaje = viaje.Numero,
                        Origen = viaje.Recorrido.Origen.Nombre,
                        Destino = viaje.Recorrido.Destino.Nombre,
                        Fecha = viaje.FechaHoraSalida.ToString("dd/MM/yyyy HH:mm"),
                        CantidadPasajeros = cantidad
                    }
                };
                return;
            }

            if (tipoReporte == "Pasajeros por ruta")
            {
                List<PasajerosPorRuta> resultado = gestionService.ObtenerPasajerosPorRuta();
                lblResultado.Text = "Rutas informadas: " + resultado.Count;
                dgvResultado.DataSource = resultado;
                return;
            }

            if (tipoReporte == "Pasajeros por categoria")
            {
                List<PasajerosPorCategoria> resultado = gestionService.ObtenerPasajerosPorCategoria();
                lblResultado.Text = "Categorias informadas: " + resultado.Count;
                dgvResultado.DataSource = resultado;
            }
        }
    }
}
