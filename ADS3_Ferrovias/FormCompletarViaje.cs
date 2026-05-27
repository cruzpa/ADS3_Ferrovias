using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BE;

namespace ADS3_Ferrovias
{
    public partial class FormCompletarViaje : Form
    {
        private readonly ViajeResultadoBusqueda viajeSeleccionado;
        private readonly int cantidadPasajeros;
        private readonly List<string> asientosDisponibles;

        public FormCompletarViaje()
            : this(null, 1)
        {
        }

        public FormCompletarViaje(ViajeResultadoBusqueda viajeSeleccionado, int cantidadPasajeros)
        {
            InitializeComponent();

            this.viajeSeleccionado = viajeSeleccionado;
            this.cantidadPasajeros = Math.Max(1, cantidadPasajeros);
            this.asientosDisponibles = ObtenerAsientosDisponibles();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void FormCompletarViaje_Load(object sender, EventArgs e)
        {
            CargarDetalleViaje();
            ConfigurarGrillaPasajeros();
            CargarPasajeros();
            ActualizarResumenCompra();
        }

        private void CargarDetalleViaje()
        {
            if (viajeSeleccionado == null)
            {
                lblDetalleViaje.Text = "Detalle del viaje\n\nNo hay un viaje seleccionado.";
                return;
            }

            decimal precioUnitario = viajeSeleccionado.PrecioEstimado / cantidadPasajeros;

            lblDetalleViaje.Text =
                "Detalle del viaje\n\n" +
                "Origen: " + viajeSeleccionado.Origen + "\n" +
                "Destino: " + viajeSeleccionado.Destino + "\n" +
                "Fecha: " + viajeSeleccionado.FechaSalida.ToString("dd/MM/yyyy") + "\n" +
                "Hora: " + viajeSeleccionado.HoraSalida.ToString(@"hh\:mm") + "\n" +
                "Duracion: " + viajeSeleccionado.DuracionEstimada + "\n" +
                "Categoria: " + viajeSeleccionado.Categoria + "\n" +
                "Precio por pasajero: $" + precioUnitario.ToString("0.00");
        }

        private void ConfigurarGrillaPasajeros()
        {
            dgvPasajeros.AutoGenerateColumns = false;
            dgvPasajeros.AllowUserToAddRows = false;
            dgvPasajeros.AllowUserToDeleteRows = false;
            dgvPasajeros.AllowUserToResizeRows = false;
            dgvPasajeros.RowHeadersVisible = false;
            dgvPasajeros.MultiSelect = false;
            dgvPasajeros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajeros.Columns.Clear();

            dgvPasajeros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NroPasajero",
                HeaderText = "Nro",
                ReadOnly = true,
                FillWeight = 40
            });

            dgvPasajeros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre"
            });

            dgvPasajeros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                HeaderText = "Apellido"
            });

            dgvPasajeros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Dni",
                HeaderText = "DNI"
            });

            dgvPasajeros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaNacimiento",
                HeaderText = "Fecha nacimiento"
            });

            dgvPasajeros.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Asiento",
                HeaderText = "Asiento"
            });

            dgvPasajeros.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Responsable",
                HeaderText = "Responsable"
            });

            dgvPasajeros.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Parentesco",
                HeaderText = "Parentesco",
                DataSource = Enum.GetValues(typeof(Parentesco))
            });

            dgvPasajeros.CellValueChanged += dgvPasajeros_CellValueChanged;
            dgvPasajeros.CurrentCellDirtyStateChanged += dgvPasajeros_CurrentCellDirtyStateChanged;
            dgvPasajeros.DataError += dgvPasajeros_DataError;
        }

        private void CargarPasajeros()
        {
            dgvPasajeros.Rows.Clear();

            for (int i = 1; i <= cantidadPasajeros; i++)
            {
                int rowIndex = dgvPasajeros.Rows.Add();
                DataGridViewRow row = dgvPasajeros.Rows[rowIndex];

                row.Cells["NroPasajero"].Value = i;
                row.Cells["FechaNacimiento"].Value = DateTime.Today.ToString("dd/MM/yyyy");
                ActualizarResponsableYParentesco(row);
            }

            ActualizarResponsablesDisponibles();
            ActualizarAsientosDisponibles();
        }

        private List<string> ObtenerAsientosDisponibles()
        {
            if (viajeSeleccionado == null || viajeSeleccionado.Viaje == null || viajeSeleccionado.Viaje.Formacion == null)
            {
                return new List<string>();
            }

            Categoria categoriaSeleccionada;

            if (!Enum.TryParse(viajeSeleccionado.Categoria, out categoriaSeleccionada))
            {
                return new List<string>();
            }

            return viajeSeleccionado.Viaje.Formacion.Vagones
                .Where(vagon => vagon.Categoria == categoriaSeleccionada)
                .SelectMany(vagon => vagon.Butacas.Select(butaca => "V" + vagon.Numero + " - " + butaca.Numero))
                .ToList();
        }

        private void ActualizarResponsablesDisponibles()
        {
            foreach (DataGridViewRow row in dgvPasajeros.Rows)
            {
                DataGridViewComboBoxCell responsableCell = row.Cells["Responsable"] as DataGridViewComboBoxCell;

                if (responsableCell == null)
                {
                    continue;
                }

                object valorActual = responsableCell.Value;
                responsableCell.Items.Clear();
                responsableCell.Items.Add("");

                foreach (DataGridViewRow otraFila in dgvPasajeros.Rows)
                {
                    if (otraFila.Index == row.Index)
                    {
                        continue;
                    }

                    responsableCell.Items.Add(ObtenerNombrePasajero(otraFila));
                }

                if (valorActual != null && responsableCell.Items.Contains(valorActual))
                {
                    responsableCell.Value = valorActual;
                }
                else
                {
                    responsableCell.Value = "";
                }
            }
        }

        private void ActualizarAsientosDisponibles()
        {
            List<string> asientosSeleccionados = dgvPasajeros.Rows
                .Cast<DataGridViewRow>()
                .Select(row => Convert.ToString(row.Cells["Asiento"].Value))
                .Where(asiento => !string.IsNullOrWhiteSpace(asiento))
                .ToList();

            foreach (DataGridViewRow row in dgvPasajeros.Rows)
            {
                DataGridViewComboBoxCell asientoCell = row.Cells["Asiento"] as DataGridViewComboBoxCell;

                if (asientoCell == null)
                {
                    continue;
                }

                string valorActual = Convert.ToString(asientoCell.Value);
                asientoCell.Items.Clear();
                asientoCell.Items.Add("");

                foreach (string asiento in asientosDisponibles)
                {
                    bool seleccionadoEnOtraFila = asientosSeleccionados.Contains(asiento) && asiento != valorActual;

                    if (!seleccionadoEnOtraFila)
                    {
                        asientoCell.Items.Add(asiento);
                    }
                }

                if (!string.IsNullOrWhiteSpace(valorActual) && asientoCell.Items.Contains(valorActual))
                {
                    asientoCell.Value = valorActual;
                }
                else
                {
                    asientoCell.Value = "";
                }
            }
        }

        private string ObtenerNombrePasajero(DataGridViewRow row)
        {
            string nro = Convert.ToString(row.Cells["NroPasajero"].Value);
            string nombre = Convert.ToString(row.Cells["Nombre"].Value);
            string apellido = Convert.ToString(row.Cells["Apellido"].Value);
            string nombreCompleto = (nombre + " " + apellido).Trim();

            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                return "Pasajero " + nro;
            }

            return "Pasajero " + nro + " - " + nombreCompleto;
        }

        private void ActualizarResumenCompra()
        {
            List<string> asientosSeleccionados = dgvPasajeros.Rows
                .Cast<DataGridViewRow>()
                .Select(row => Convert.ToString(row.Cells["Asiento"].Value))
                .Where(asiento => !string.IsNullOrWhiteSpace(asiento))
                .ToList();

            decimal precioUnitario = 0;
            decimal total = 0;

            if (viajeSeleccionado != null)
            {
                precioUnitario = viajeSeleccionado.PrecioEstimado / cantidadPasajeros;
                total = viajeSeleccionado.PrecioEstimado;
            }

            lblResumenViaje.Text =
                "Resumen\n\n" +
                "Pasajeros: " + cantidadPasajeros + "\n" +
                "Asientos: " + (asientosSeleccionados.Any() ? string.Join(", ", asientosSeleccionados) : "sin seleccionar") + "\n" +
                "Precio unitario: $" + precioUnitario.ToString("0.00") + "\n" +
                "Total: $" + total.ToString("0.00") + "\n\n" +
                "Estado: " + ObtenerEstadoCompra(asientosSeleccionados);
        }

        private string ObtenerEstadoCompra(List<string> asientosSeleccionados)
        {
            if (asientosSeleccionados.Count < cantidadPasajeros)
            {
                return "faltan seleccionar asientos";
            }

            if (asientosSeleccionados.Distinct().Count() != asientosSeleccionados.Count)
            {
                return "hay asientos repetidos";
            }

            return "listo para validar datos";
        }

        private void dgvPasajeros_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string columna = dgvPasajeros.Columns[e.ColumnIndex].Name;

            if (columna == "Nombre" || columna == "Apellido")
            {
                ActualizarResponsablesDisponibles();
            }

            if (columna == "FechaNacimiento")
            {
                ActualizarResponsableYParentesco(dgvPasajeros.Rows[e.RowIndex]);
            }

            if (columna == "Asiento")
            {
                ActualizarAsientosDisponibles();
            }

            if (columna == "Asiento" || columna == "Nombre" || columna == "Apellido")
            {
                ActualizarResumenCompra();
            }
        }

        private void ActualizarResponsableYParentesco(DataGridViewRow row)
        {
            bool esAdulto = EsAdulto(Convert.ToString(row.Cells["FechaNacimiento"].Value));

            row.Cells["Responsable"].ReadOnly = esAdulto;
            row.Cells["Parentesco"].ReadOnly = esAdulto;

            if (esAdulto)
            {
                row.Cells["Responsable"].Value = "";
                row.Cells["Parentesco"].Value = null;
                row.Cells["Responsable"].Style.BackColor = SystemColors.Control;
                row.Cells["Parentesco"].Style.BackColor = SystemColors.Control;
            }
            else
            {
                row.Cells["Responsable"].Style.BackColor = Color.White;
                row.Cells["Parentesco"].Style.BackColor = Color.White;
            }
        }

        private bool EsAdulto(string fechaNacimiento)
        {
            DateTime fecha;

            if (!DateTime.TryParseExact(fechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha) &&
                !DateTime.TryParse(fechaNacimiento, out fecha))
            {
                return false;
            }

            int edad = DateTime.Today.Year - fecha.Year;

            if (fecha.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            return edad >= 18;
        }

        private void dgvPasajeros_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPasajeros.IsCurrentCellDirty)
            {
                dgvPasajeros.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPasajeros_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = this.MdiParent as MenuPrincipal;

            Close();

            if (menuPrincipal != null)
            {
                menuPrincipal.MostrarBuscarViaje();
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string mensajeValidacion;

            if (!ValidarDatosPasajeros(out mensajeValidacion))
            {
                MessageBox.Show(mensajeValidacion, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MenuPrincipal menuPrincipal = this.MdiParent as MenuPrincipal;

            if (menuPrincipal != null)
            {
                menuPrincipal.AbrirComprarViaje(ObtenerDetalleCompra(), ObtenerPasajerosCompra(), ObtenerPrecioTotal());
            }
            else
            {
                FormComprarViaje formComprarViaje = new FormComprarViaje(ObtenerDetalleCompra(), ObtenerPasajerosCompra(), ObtenerPrecioTotal());
                formComprarViaje.Show();
            }
        }

        private string ObtenerDetalleCompra()
        {
            List<string> asientosSeleccionados = dgvPasajeros.Rows
                .Cast<DataGridViewRow>()
                .Select(row => Convert.ToString(row.Cells["Asiento"].Value))
                .Where(asiento => !string.IsNullOrWhiteSpace(asiento))
                .ToList();

            if (viajeSeleccionado == null)
            {
                return "Detalle de compra\n\nTotal: pendiente";
            }

            return
                "Detalle de compra\n\n" +
                "Origen: " + viajeSeleccionado.Origen + "\n" +
                "Destino: " + viajeSeleccionado.Destino + "\n" +
                "Fecha: " + viajeSeleccionado.FechaSalida.ToString("dd/MM/yyyy") + "\n" +
                "Hora: " + viajeSeleccionado.HoraSalida.ToString(@"hh\:mm") + "\n" +
                "Pasajeros: " + cantidadPasajeros + "\n" +
                "Asientos: " + string.Join(", ", asientosSeleccionados) + "\n" +
                "Total: $" + viajeSeleccionado.PrecioEstimado.ToString("0.00");
        }

        private List<PasajeroCompraDetalle> ObtenerPasajerosCompra()
        {
            return dgvPasajeros.Rows
                .Cast<DataGridViewRow>()
                .Select(row => new PasajeroCompraDetalle
                {
                    Nombre = Convert.ToString(row.Cells["Nombre"].Value),
                    Apellido = Convert.ToString(row.Cells["Apellido"].Value),
                    Dni = Convert.ToString(row.Cells["Dni"].Value),
                    FechaNacimiento = Convert.ToString(row.Cells["FechaNacimiento"].Value),
                    Asiento = Convert.ToString(row.Cells["Asiento"].Value),
                    Responsable = Convert.ToString(row.Cells["Responsable"].Value),
                    Parentesco = Convert.ToString(row.Cells["Parentesco"].Value)
                })
                .ToList();
        }

        private decimal ObtenerPrecioTotal()
        {
            return viajeSeleccionado == null ? 0 : viajeSeleccionado.PrecioEstimado;
        }

        private bool ValidarDatosPasajeros(out string mensaje)
        {
            List<DataGridViewRow> filas = dgvPasajeros.Rows.Cast<DataGridViewRow>().ToList();
            bool hayAdultos = filas.Any(EsFilaAdulto);

            foreach (DataGridViewRow row in filas)
            {
                string nroPasajero = Convert.ToString(row.Cells["NroPasajero"].Value);
                string nombre = Convert.ToString(row.Cells["Nombre"].Value);
                string apellido = Convert.ToString(row.Cells["Apellido"].Value);
                string dni = Convert.ToString(row.Cells["Dni"].Value);
                string fechaNacimiento = Convert.ToString(row.Cells["FechaNacimiento"].Value);
                string asiento = Convert.ToString(row.Cells["Asiento"].Value);
                string responsable = Convert.ToString(row.Cells["Responsable"].Value);
                string parentesco = Convert.ToString(row.Cells["Parentesco"].Value);

                if (string.IsNullOrWhiteSpace(nombre) ||
                    string.IsNullOrWhiteSpace(apellido) ||
                    string.IsNullOrWhiteSpace(dni) ||
                    string.IsNullOrWhiteSpace(fechaNacimiento) ||
                    string.IsNullOrWhiteSpace(asiento))
                {
                    mensaje = "Complete todos los datos obligatorios del pasajero " + nroPasajero + ".";
                    return false;
                }

                if (!dni.All(char.IsDigit) || dni.Length < 7 || dni.Length > 8)
                {
                    mensaje = "El DNI del pasajero " + nroPasajero + " no es valido.";
                    return false;
                }

                DateTime fecha;

                if (!TryParseFechaNacimiento(fechaNacimiento, out fecha) || fecha.Date > DateTime.Today)
                {
                    mensaje = "La fecha de nacimiento del pasajero " + nroPasajero + " no es valida.";
                    return false;
                }

                if (!EsAdulto(fechaNacimiento))
                {
                    if (!hayAdultos)
                    {
                        mensaje = "No se permite viajar menores sin al menos un adulto responsable.";
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(responsable) || string.IsNullOrWhiteSpace(parentesco))
                    {
                        mensaje = "Indique responsable y parentesco para el pasajero menor " + nroPasajero + ".";
                        return false;
                    }

                    DataGridViewRow filaResponsable = BuscarFilaResponsable(responsable);

                    if (filaResponsable == null || !EsFilaAdulto(filaResponsable))
                    {
                        mensaje = "El responsable del pasajero " + nroPasajero + " debe ser un pasajero adulto.";
                        return false;
                    }
                }
            }

            mensaje = "";
            return true;
        }

        private bool EsFilaAdulto(DataGridViewRow row)
        {
            return EsAdulto(Convert.ToString(row.Cells["FechaNacimiento"].Value));
        }

        private DataGridViewRow BuscarFilaResponsable(string responsable)
        {
            return dgvPasajeros.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(row => ObtenerNombrePasajero(row) == responsable);
        }

        private bool TryParseFechaNacimiento(string fechaNacimiento, out DateTime fecha)
        {
            return DateTime.TryParseExact(fechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha) ||
                   DateTime.TryParse(fechaNacimiento, out fecha);
        }
    }
}
