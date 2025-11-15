using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_Boletos_Aéreos
{
    public partial class TripulacionVueloForm : Form
    {
        private TripulacionVueloDAO tripulacionVueloDAO;
        private int tripulacionVueloIdSeleccionado = 0;

        public TripulacionVueloForm()
        {
            InitializeComponent();
            tripulacionVueloDAO = new TripulacionVueloDAO();
        }

        private void TripulacionVueloForm_Load(object sender, EventArgs e)
        {
            CargarTripulacionesVuelo();
            CargarTripulaciones();
            CargarVuelos();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvTripulacionVuelo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTripulacionVuelo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTripulacionVuelo.MultiSelect = false;
            dgvTripulacionVuelo.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                int vueloId = Convert.ToInt32(cmbVuelo.SelectedValue);
                int tripulacionId = Convert.ToInt32(cmbTripulacion.SelectedValue);

                if (tripulacionVueloIdSeleccionado == 0) // Nuevo tripulacion vuelo
                {
                    bool resultado = tripulacionVueloDAO.InsertarTripulacionVuelo(
                        vueloId,
                        tripulacionId
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Tripulación asignada al vuelo exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVuelos();
                        CargarTripulaciones();
                        CargarTripulacionesVuelo();
                        LimpiarCampos();
                    }
                }
                else // Actualizar
                {
                    bool resultado = tripulacionVueloDAO.ActualizarTripulacionVuelo(
                        tripulacionVueloIdSeleccionado,
                        vueloId,
                        tripulacionId
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Asignación actualizada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVuelos();
                        CargarTripulaciones();
                        CargarTripulacionesVuelo();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la asignación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbVuelo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un vuelo", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVuelo.Focus();
                return false;
            }

            if (cmbTripulacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una tripulación", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTripulacion.Focus();
                return false;
            }

            return true;
        }

        private void CargarTripulacionesVuelo()
        {
            try
            {
                DataTable dt = tripulacionVueloDAO.ConsultarTripulacionVuelo();
                dgvTripulacionVuelo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaciones: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CORREGIDO: Método que estaba vacío
        private void CargarVuelos()
        {
            try
            {
                VueloDAO vuelo = new VueloDAO();
                DataTable dt = vuelo.ConsultarVuelos();

                // Crear columna combinada para mostrar información completa del vuelo
                dt.Columns.Add("DescripcionVuelo", typeof(string),
                    "NumeroVuelo + ' - ' + CiudadOrigen + ' → ' + CiudadDestino");

                cmbVuelo.DataSource = dt;
                cmbVuelo.DisplayMember = "DescripcionVuelo";
                cmbVuelo.ValueMember = "Id";
                cmbVuelo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vuelos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTripulaciones()
        {
            try
            {
                TripulacionDAO tripulacion = new TripulacionDAO();
                DataTable dt = tripulacion.ConsultarTripulantes();

                // Crear columna combinada para mostrar información completa
                dt.Columns.Add("DescripcionTripulacion", typeof(string),
                    "Nombre + ' ' + Apellido + ' - ' + Cargo + ' (' + Identificacion + ')'");

                cmbTripulacion.DataSource = dt;
                cmbTripulacion.DisplayMember = "DescripcionTripulacion";
                cmbTripulacion.ValueMember = "Id";
                cmbTripulacion.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tripulantes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvTripulacionVuelo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una asignación de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvTripulacionVuelo.SelectedRows[0];

                tripulacionVueloIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                cmbVuelo.SelectedValue = row.Cells["VueloId"].Value;
                cmbTripulacion.SelectedValue = row.Cells["TripulacionId"].Value;

                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la asignación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            tripulacionVueloIdSeleccionado = 0;
            cmbVuelo.SelectedIndex = -1;
            cmbTripulacion.SelectedIndex = -1;

            btnGuardar.Text = "Guardar";
            cmbVuelo.Focus();
        }

        private void dgvTripulacionVuelo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método vacío - evento no usado
        }

        private void dgvTripulacionVuelo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button1_Click(sender, e);
            }
        }
    }
}