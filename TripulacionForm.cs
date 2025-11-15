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
    public partial class TripulacionForm : Form
    {
        private TripulacionDAO tripulacionDAO;

        private int tripulacionIdSeleccionado = 0;

        public TripulacionForm()
        {
            InitializeComponent();
            tripulacionDAO = new TripulacionDAO();
        }

        private void ConfigurarDataGridView()
        {
            dgvTripulacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTripulacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTripulacion.MultiSelect = false;
            dgvTripulacion.ReadOnly = true;
        }


        private void TripulacionForm_Load(object sender, EventArgs e)
        {
            CargarTripulacion();
            CargarAerolineas();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void dgvTripulacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }

        private void LimpiarCampos()
        {
            tripulacionIdSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtIdentificacion.Clear();
            txtCargo.Clear();
            
            

            btnAgregar.Text = "Agregar";

            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el apellido", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                MessageBox.Show("Ingrese la identificación", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentificacion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Ingrese el cargo", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Focus();
                return false;
            }

            if (cmbAerolinea.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una aerolinea", "Campo requerido",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAerolinea.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtFechaContratacion.Text))
            {
                MessageBox.Show("Ingrese la fecha de contratacion", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFechaContratacion.Focus();
                return false;
            }

            return true;
        }

        private void CargarAerolineas()
        {

            AerolineaDAO aerolinea = new AerolineaDAO();
            DataTable dt = aerolinea.ConsultarAerolineas();

            cmbAerolinea.DataSource = dt;

            dt.Columns.Add("DescripcionAerolinea", typeof(string),
                "Codigo +  ' - ' + Nombre");

            cmbAerolinea.DisplayMember = "DescripcionAerolinea";
            cmbAerolinea.ValueMember = "Id";

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {

                int aerolineaId = Convert.ToInt32(cmbAerolinea.SelectedValue);

                Console.WriteLine("ID DE AEROLINEA" + aerolineaId);

                if (tripulacionIdSeleccionado == 0) // Nueva tripulacion
                {
                    DateTime fechaSeleccionada = dtFechaContratacion.Value.Date;

                    bool resultado = tripulacionDAO.InsertarTripulacion(
                        
                    
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        txtIdentificacion.Text.Trim(),
                        txtCargo.Text.Trim(),
                        aerolineaId,
                        fechaSeleccionada
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Tripulación guardada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTripulacion();
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
                else // Actualizar tripulación
                {
                    DateTime fechaSeleccionada = dtFechaContratacion.Value.Date;

                    bool resultado = tripulacionDAO.ActualizarTripulante(
                        tripulacionIdSeleccionado,
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        txtIdentificacion.Text.Trim(),
                        txtCargo.Text.Trim(),
                        aerolineaId,
                        fechaSeleccionada

                    );

                    if (resultado)
                    {
                        MessageBox.Show("Tripulación actualizada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTripulacion();
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar tripulación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTripulacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una tripulacion de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvTripulacion.SelectedRows[0];

                tripulacionIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtIdentificacion.Text = row.Cells["Identificacion"].Value.ToString();
                txtCargo.Text = row.Cells["Cargo"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(row.Cells["FechaContratacion"].Value);
                DateTime soloFecha = fecha.Date;

                // Selecciona la aerolínea en el ComboBox
                cmbAerolinea.SelectedValue = row.Cells["AerolineaId"].Value;

             
                btnAgregar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la tripulacion: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTripulacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una tripulacion de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvTripulacion.SelectedRows[0].Cells["Id"].Value);
                string nombre = dgvTripulacion.SelectedRows[0].Cells["Nombre"].Value.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de eliminar la tripulacion '{nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    bool eliminado = tripulacionDAO.EliminarTripulacion(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Tripulacion eliminada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAerolineas();
                        CargarTripulacion();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la tripulacion: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CargarTripulacion()
        {
            try
            {
                DataTable dt = tripulacionDAO.ConsultarTripulantes();
                dgvTripulacion.DataSource = dt;
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error al cargar la tripulacion: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

    }
}
