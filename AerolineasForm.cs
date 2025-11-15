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
    public partial class AerolineasForm : Form
    {

        private AerolineaDAO aerolineaDAO;
        private int aerolineaIdSeleccionado = 0;

        public AerolineasForm()
        {
            InitializeComponent();
            aerolineaDAO = new AerolineaDAO();
        }

        private void AerolineasForm_Load(object sender, EventArgs e)
        {
            CargarAerolineas();
            ConfigurarDataGridView();
            LimpiarCampos();
        }


        private void ConfigurarDataGridView()
        {
            dgvAerolineas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAerolineas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAerolineas.MultiSelect = false;
            dgvAerolineas.ReadOnly = true;
        }

        private void CargarAerolineas()
        {
            try
            {
                DataTable dt = aerolineaDAO.ConsultarAerolineas();
                dgvAerolineas.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar aerolineas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;

            try
            {
                if (aerolineaIdSeleccionado == 0) // Nuevo aerolinea
                {
                    bool resultado = aerolineaDAO.InsertarAerolinea(
                        txtNombre.Text.Trim(),
                        txtCodigo.Text.Trim(),
                        txtPais.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim()
                    ) ;

                    if (resultado)
                    {
                        MessageBox.Show("Aerolinea guardada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
                else // Actualizar aerolinea
                {
                    bool resultado = aerolineaDAO.ActualizarAerolinea(
                        aerolineaIdSeleccionado,
                        txtNombre.Text.Trim(),
                        txtCodigo.Text.Trim(),
                        txtPais.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim()
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Aerolinea actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la aerolinea: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la aerolinea", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            /*
                // espacio para comentarios aqui ->

            ->
             */

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) && aerolineaIdSeleccionado == 0)
            {
                MessageBox.Show("Ingrese el codigo", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                MessageBox.Show("Ingrese el pais", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPais.Focus();
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
                MessageBox.Show("Ingrese un telefono", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            return true;
        }



        private void LimpiarCampos()
        {
            aerolineaIdSeleccionado = 0;
            txtNombre.Clear();
            txtCodigo.Clear();
            txtPais.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            btnGuardar.Text = "Guardar";

            txtNombre.Focus();
        }

        private void dgvAerolineas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAerolineas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una aerolinea de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvAerolineas.SelectedRows[0];

                aerolineaIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
                txtPais.Text = row.Cells["Pais"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la aerolinea: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAerolineas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una aerolinea de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvAerolineas.SelectedRows[0].Cells["Id"].Value);
                string nombre = dgvAerolineas.SelectedRows[0].Cells["Nombre"].Value.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de eliminar la aerolinea '{nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    bool eliminado = aerolineaDAO.EliminarAerolinea(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Aerolinea eliminada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la aerolinea: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
