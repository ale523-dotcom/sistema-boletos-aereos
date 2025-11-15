using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        MessageBox.Show("Tripulacion vuelo guardada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVuelos();
                        CargarTripulaciones();
                        CargarTripulacionesVuelo();
                        LimpiarCampos();
                    }
                }
                else // Actualizar aerolinea
                {
                    bool resultado = tripulacionVueloDAO.ActualizarTripulacionVuelo(
                        tripulacionVueloIdSeleccionado,
                        vueloId,
                        tripulacionId
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Tripulacion vuelo actualizado exitosamente!", "Éxito",
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
                MessageBox.Show("Error al guardar la tripulacion vuelo: " + ex.Message, "Error",
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
                MessageBox.Show("Seleccione una tripulacion", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVuelo.Focus();
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
                MessageBox.Show("Error al cargar la tripulacion vuelo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvTripulacionVuelo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una tripulacion vuelo de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvTripulacionVuelo.SelectedRows[0];

                tripulacionVueloIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);

                cmbTripulacion.SelectedValue = row.Cells["TripulacionId"].Value;
                cmbVuelo.SelectedValue = row.Cells["VueloId"].Value;



                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la tripulacion del vuelo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void TripulacionVueloForm_Load(object sender, EventArgs e)
        {
            CargarTripulacionesVuelo();
            CargarTripulaciones();
            CargarVuelos();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void dgvTripulacionVuelo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void LimpiarCampos()
        {
            tripulacionVueloIdSeleccionado = 0;
            cmbVuelo.SelectedIndex = -1;
            cmbTripulacion.SelectedIndex = -1;


            btnGuardar.Text = "Guardar";

            cmbVuelo.Focus();
        }


        private void CargarVuelos()
        {
            
        }

        private void ConfigurarDataGridView()
        {
            dgvTripulacionVuelo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTripulacionVuelo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTripulacionVuelo.MultiSelect = false;
            dgvTripulacionVuelo.ReadOnly = true;
        }


        private void CargarTripulaciones()
        {
            TripulacionDAO tripulacion = new TripulacionDAO();
            DataTable dt = tripulacion.ConsultarTripulantes();

            cmbTripulacion.DataSource = dt;


            dt.Columns.Add("DescripcionTripulacion", typeof(string), "Nombre + ' ' + Apellido + ' ' + Identificacion");

            cmbTripulacion.DisplayMember = "DescripcionTripulacion";
            cmbTripulacion.ValueMember = "Id";

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
