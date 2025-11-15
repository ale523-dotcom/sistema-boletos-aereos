using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_Boletos_Aéreos
{
    public partial class VueloForm : Form
    {
        private VueloDAO vueloDAO;
        private int vueloIdSeleccionado = 0;

        public VueloForm()
        {
            InitializeComponent();
            vueloDAO = new VueloDAO();
        }

        private void VueloForm_Load(object sender, EventArgs e)
        {
            CargarVuelos();
            CargarAerolineas();
            CargarRutas();
            CargarAviones();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvVuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVuelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVuelos.MultiSelect = false;
            dgvVuelos.ReadOnly = true;
        }

        private void CargarVuelos()
        {
            try
            {
                DataTable dt = vueloDAO.ConsultarVuelos();
                dgvVuelos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vuelos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAerolineas()
        {
            AerolineaDAO aerolinea = new AerolineaDAO();
            DataTable dt = aerolinea.ConsultarAerolineas();

            dt.Columns.Add("DescripcionAerolinea", typeof(string), "Codigo + ' - ' + Nombre");

            cmbAerolinea.DataSource = dt;
            cmbAerolinea.DisplayMember = "DescripcionAerolinea";
            cmbAerolinea.ValueMember = "Id";
        }

        private void CargarRutas()
        {
            RutaDAO ruta = new RutaDAO();
            DataTable dt = ruta.ConsultarRutas();

            dt.Columns.Add("DescripcionRuta", typeof(string),
                "CiudadOrigen + ' → ' + CiudadDestino");

            cmbRuta.DataSource = dt;
            cmbRuta.DisplayMember = "DescripcionRuta";
            cmbRuta.ValueMember = "Id";
        }

        private void CargarAviones()
        {
            AvionDAO avion = new AvionDAO();
            DataTable dt = avion.ConsultarAviones();

            dt.Columns.Add("DescripcionAvion", typeof(string),
                "Modelo + ' - ' + NumeroSerie");

            cmbAvion.DataSource = dt;
            cmbAvion.DisplayMember = "DescripcionAvion";
            cmbAvion.ValueMember = "Id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                int aerolineaId = Convert.ToInt32(cmbAerolinea.SelectedValue);
                int rutaId = Convert.ToInt32(cmbRuta.SelectedValue);
                int avionId = Convert.ToInt32(cmbAvion.SelectedValue);

                if (vueloIdSeleccionado == 0) // Nuevo vuelo
                {
                    bool resultado = vueloDAO.InsertarVuelo(
                        txtNumeroVuelo.Text.Trim(),
                        aerolineaId,
                        rutaId,
                        avionId,
                        dtpFechaSalida.Value,
                        dtpFechaLlegada.Value,
                        numTarifaBase.Value,
                        (int)numAsientos.Value
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Vuelo guardado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVuelos();
                        LimpiarCampos();
                    }
                }
                else // Actualizar vuelo
                {
                    bool resultado = vueloDAO.ActualizarVuelo(
                        vueloIdSeleccionado,
                        txtNumeroVuelo.Text.Trim(),
                        aerolineaId,
                        rutaId,
                        avionId,
                        dtpFechaSalida.Value,
                        dtpFechaLlegada.Value,
                        numTarifaBase.Value,
                        (int)numAsientos.Value,
                        cmbEstado.Text
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Vuelo actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVuelos();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar vuelo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNumeroVuelo.Text))
            {
                MessageBox.Show("Ingrese el número de vuelo", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroVuelo.Focus();
                return false;
            }

            if (cmbAerolinea.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una aerolínea", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAerolinea.Focus();
                return false;
            }

            if (cmbRuta.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una ruta", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRuta.Focus();
                return false;
            }

            if (cmbAvion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un avión", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAvion.Focus();
                return false;
            }

            if (dtpFechaSalida.Value >= dtpFechaLlegada.Value)
            {
                MessageBox.Show("La fecha de llegada debe ser posterior a la fecha de salida",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numTarifaBase.Value <= 0)
            {
                MessageBox.Show("Ingrese una tarifa válida", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numTarifaBase.Focus();
                return false;
            }

            if (numAsientos.Value <= 0)
            {
                MessageBox.Show("Ingrese el número de asientos disponibles", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAsientos.Focus();
                return false;
            }

            return true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un vuelo de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvVuelos.SelectedRows[0];

                vueloIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNumeroVuelo.Text = row.Cells["NumeroVuelo"].Value.ToString();
                cmbAerolinea.SelectedValue = row.Cells["AerolineaId"].Value;
                cmbRuta.SelectedValue = row.Cells["RutaId"].Value;
                cmbAvion.SelectedValue = row.Cells["AvionId"].Value;
                dtpFechaSalida.Value = Convert.ToDateTime(row.Cells["FechaSalida"].Value);
                dtpFechaLlegada.Value = Convert.ToDateTime(row.Cells["FechaLlegada"].Value);
                numTarifaBase.Value = Convert.ToDecimal(row.Cells["TarifaBase"].Value);
                numAsientos.Value = Convert.ToInt32(row.Cells["AsientosDisponibles"].Value);
                cmbEstado.Text = row.Cells["Estado"].Value.ToString();

                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del vuelo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un vuelo de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvVuelos.SelectedRows[0].Cells["Id"].Value);
                string numero = dgvVuelos.SelectedRows[0].Cells["NumeroVuelo"].Value.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de cancelar el vuelo '{numero}'?",
                    "Confirmar cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    bool cancelado = vueloDAO.CancelarVuelo(id);

                    if (cancelado)
                    {
                        MessageBox.Show("Vuelo cancelado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVuelos();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar vuelo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            vueloIdSeleccionado = 0;
            txtNumeroVuelo.Clear();
            cmbAerolinea.SelectedIndex = -1;
            cmbRuta.SelectedIndex = -1;
            cmbAvion.SelectedIndex = -1;
            dtpFechaSalida.Value = DateTime.Now;
            dtpFechaLlegada.Value = DateTime.Now.AddHours(2);
            numTarifaBase.Value = 0;
            numAsientos.Value = 0;
            cmbEstado.SelectedIndex = 0;

            btnGuardar.Text = "Guardar";
            txtNumeroVuelo.Focus();
        }

        private void dgvVuelos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }
    }
}