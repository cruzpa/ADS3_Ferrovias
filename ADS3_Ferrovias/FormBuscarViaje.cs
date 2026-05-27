using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ADS3_Ferrovias
{
    public partial class FormBuscarViaje : Form
    {
        EstacionService estacionService = new EstacionService();
        ViajeService viajeService = new ViajeService(); 
        public FormBuscarViaje()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            dgvViajes.CellContentClick += dgvViajes_CellContentClick;
        }

        private void FormBuscarViaje_Load(object sender, EventArgs e)
        {
            ConfigurarFormularioBusquedaViajes();
            CargarEstaciones();
            CargarCategorias();
            nudCantidadPasajeros.Value = 1;
        }

        private void CargarCategorias()
        {
            cbCategoria.DataSource = Enum.GetValues(typeof(Categoria));
        }

        private void CargarEstaciones()
        {
            List<Estacion> estaciones = estacionService.Listar();
            cbOrigen.DataSource = estaciones.ToList();
            cbOrigen.DisplayMember = "Nombre";

            cbDestino.DataSource = estaciones.ToList();
            cbDestino.DisplayMember = "Nombre";
            cbDestino.SelectedItem = estaciones.Last();
        }

        private void ConfigurarFormularioBusquedaViajes()
        {
            dtpFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpFechaSalida.CustomFormat = "dd/MM/yyyy";

            dgvViajes.AutoGenerateColumns = false;
            dgvViajes.AllowUserToAddRows = false;
            dgvViajes.AllowUserToDeleteRows = false;
            dgvViajes.AllowUserToResizeRows = false;
            dgvViajes.MultiSelect = false;
            dgvViajes.ReadOnly = true;
            dgvViajes.RowHeadersVisible = false;
            dgvViajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvViajes.Columns.Clear();
            dgvViajes.Columns.Add(CrearColumnaTexto("FechaSalida", "Fecha salida"));
            dgvViajes.Columns.Add(CrearColumnaTexto("HoraSalida", "Hora salida"));
            dgvViajes.Columns.Add(CrearColumnaTexto("Origen", "Origen"));
            dgvViajes.Columns.Add(CrearColumnaTexto("Destino", "Destino"));
            dgvViajes.Columns.Add(CrearColumnaTexto("DuracionEstimada", "Duración"));
            dgvViajes.Columns.Add(CrearColumnaTexto("CantidadParadas", "Paradas"));
            dgvViajes.Columns.Add(CrearColumnaTexto("Categoria", "Categoría"));
            dgvViajes.Columns.Add(CrearColumnaTexto("LugaresDisponibles", "Disponibles"));
            dgvViajes.Columns.Add(CrearColumnaTexto("PrecioEstimado", "Precio estimado"));
            dgvViajes.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Seleccionar",
                HeaderText = "",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true
            });
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaSalida = dtpFechaSalida.Value.Date;
            Estacion origen = cbOrigen.SelectedItem as Estacion;
            Estacion destino = cbDestino.SelectedItem as Estacion;
            int cantidadPasajeros = (int)nudCantidadPasajeros.Value;
            string categoria = cbCategoria.SelectedItem?.ToString();

            if (origen == null || destino == null || cantidadPasajeros <= 0 || string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Completá todos los datos para buscar viajes.");
                return;
            }

            if (origen == destino)
            {
                MessageBox.Show("El origen y el destino no pueden ser iguales.");
                return;
            }

            List<ViajeResultadoBusqueda> resultados =
                viajeService.BuscarViajes(fechaSalida, origen, destino, cantidadPasajeros, categoria);

            dgvViajes.DataSource = resultados;
            foreach (var r in resultados)
            {
                Console.WriteLine(r);
            }
        }

        private void dgvViajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvViajes.Columns[e.ColumnIndex].Name != "Seleccionar")
            {
                return;
            }

            MenuPrincipal menuPrincipal = this.MdiParent as MenuPrincipal;

            if (menuPrincipal != null)
            {
                ViajeResultadoBusqueda viajeSeleccionado = dgvViajes.Rows[e.RowIndex].DataBoundItem as ViajeResultadoBusqueda;
                int cantidadPasajeros = (int)nudCantidadPasajeros.Value;

                menuPrincipal.AbrirCompletarViaje(viajeSeleccionado, cantidadPasajeros);
            }
            else
            {
                FormCompletarViaje formCompletarViaje = new FormCompletarViaje();
                formCompletarViaje.Show();
            }
        }
    }
}
