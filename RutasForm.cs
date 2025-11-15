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
    public partial class RutasForm : Form
    {

        private RutaDAO RutaDAO;
        private int rutaIdSeleccionado = 0;

        public RutasForm()
        {
            InitializeComponent();
            RutaDAO = new RutaDAO();
        }
        private void ConfigurarDataGridView()
        {
            dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutas.MultiSelect = false;
            dgvRutas.ReadOnly = true;
        }
        private void CargarRutas()
        {
            try
            {
                DataTable dt = RutaDAO.ConsultarRutas();
                dgvRutas.DataSource = dt;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar rutas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (rutaIdSeleccionado == 0) // Nueva ruta
                {
                    bool resultado = RutaDAO.InsertarRuta(
                        txtCiudadOrigen.Text.Trim(),
                        txtCiudadDestino.Text.Trim(),
                        numDistancia.Value,
                        dtDuracion.Value.ToString("HH:mm:ss")
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Ruta guardada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRutas();
                        LimpiarCampos();
                    }
                }
                else // Actualizar ruta
                {
                    bool resultado = RutaDAO.ActualizarRutas(
                        rutaIdSeleccionado,
                        txtCiudadOrigen.Text.Trim(),
                        txtCiudadDestino.Text.Trim(),
                        numDistancia.Value,
                        dtDuracion.Value.ToString("HH:mm:ss")
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Ruta actualizada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRutas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar ruta: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una ruta de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvRutas.SelectedRows[0];

                rutaIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtCiudadOrigen.Text = row.Cells["CiudadOrigen"].Value.ToString();
                txtCiudadDestino.Text = row.Cells["CiudadDestino"].Value.ToString();
                numDistancia.Value = Convert.ToDecimal(row.Cells["Distancia"].Value);

                // Obtener duración (TIME) desde la celda
                TimeSpan duracion = TimeSpan.Parse(row.Cells["DuracionEstimada"].Value.ToString());

                // Asignar al DateTimePicker usando una fecha base
                dtDuracion.Value = DateTime.Today + duracion;




                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las rutas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una ruta de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvRutas.SelectedRows[0].Cells["Id"].Value);
                string nombre = dgvRutas.SelectedRows[0].Cells["Nombre"].Value.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de eliminar la ruta '{nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    bool eliminado = RutaDAO.EliminarRuta(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Ruta eliminada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRutas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la ruta: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            rutaIdSeleccionado = 0;
            txtCiudadOrigen.Clear();
            txtCiudadDestino.Clear();
            numDistancia.Value=1;
            dtDuracion.Value = DateTime.Now;

            btnGuardar.Text = "Guardar";

            txtCiudadOrigen.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCiudadOrigen.Text))
            {
                MessageBox.Show("Ingrese la ciudad de origen", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudadOrigen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCiudadDestino.Text))
            {
                MessageBox.Show("Ingrese la ciudad de destino", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudadDestino.Focus();
                return false;
            }


            if (numDistancia.Value <= 0)
            {
                MessageBox.Show("La distancia debe ser mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDistancia.Focus();
                return false;
            }
            if (dtDuracion.Value == null)
            {
                MessageBox.Show("Seleccione una duración válida.");
                return false;
            }



            return true;
        }

        private void RutasForm_Load(object sender, EventArgs e)
        {
            CargarRutas();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void dgvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRutas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }
    }
}
