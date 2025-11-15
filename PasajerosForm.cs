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
    public partial class PasajerosForm : Form
    {

        private PasajeroDAO pasajeroDAO;

        private int pasajeroIdSeleccionado = 0;

        public PasajerosForm()
        {
            InitializeComponent();
            pasajeroDAO = new PasajeroDAO();
        }

        
        private void ConfigurarDataGridView()
        {
            dgvPasajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajeros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasajeros.MultiSelect = false;
            dgvPasajeros.ReadOnly = true;
        }
        private void CargarPasajeros()
        {
            try
            {
                DataTable dt = pasajeroDAO.ConsultarPasajeros();
                dgvPasajeros.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pasajeros: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (pasajeroIdSeleccionado == 0) // Nuevo pasajero
                {
                    DateTime fechaSeleccionada = dtFechaNacimiento.Value.Date;

                    bool resultado = pasajeroDAO.InsertarPasajero(
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        fechaSeleccionada,
                    txtNumeroPasaporte.Text.Trim(),
                        txtNacionalidad.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim()
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Pasajero guardado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPasajeros();
                        LimpiarCampos();
                    }
                }
                else // Actualizar pasajero
                {
                    DateTime fechaSeleccionada = dtFechaNacimiento.Value.Date;
                    bool resultado = pasajeroDAO.ActualizarPasajero(
                        pasajeroIdSeleccionado,
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        fechaSeleccionada,
                       txtNumeroPasaporte.Text.Trim(),
                        txtNacionalidad.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim()

                    );

                    if (resultado)
                    {
                        MessageBox.Show("Pasajero actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPasajeros();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar pasajero: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPasajeros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un pasajero de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvPasajeros.SelectedRows[0];

                pasajeroIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                DateTime soloFecha = fecha.Date;
                txtNumeroPasaporte.Text = row.Cells["NumeroPasaporte"].Value.ToString();
                txtNacionalidad.Text= row.Cells["Nacionalidad"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtTelefono.Text= row.Cells["Telefono"].Value.ToString();



                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del pasajero: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void PasajerosForm_Load(object sender, EventArgs e)
        {
            CargarPasajeros();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void dgvPasajeros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }


        private void LimpiarCampos()
        {
            pasajeroIdSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            dtFechaNacimiento.Value = DateTime.Now;
            txtNumeroPasaporte.Clear();
            txtNacionalidad.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            btnGuardar.Text = "Guardar";

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


            if (string.IsNullOrWhiteSpace(txtNumeroPasaporte.Text))
            {
                MessageBox.Show("Ingrese el numero de pasaporte", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroPasaporte.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                MessageBox.Show("Ingrese la nacionalidad", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNacionalidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el email", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el numero de telefono", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }



            return true;
        }


    }
}
