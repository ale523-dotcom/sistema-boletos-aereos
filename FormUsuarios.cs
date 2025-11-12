using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_Boletos_Aéreos
{
    public partial class FormUsuarios : Form
    {
        private UsuarioDAO usuarioDAO;
        private int usuarioIdSeleccionado = 0;

        public FormUsuarios()
        {
            InitializeComponent();
            usuarioDAO = new UsuarioDAO();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
        }

        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = usuarioDAO.ConsultarUsuarios();
                dgvUsuarios.DataSource = dt;

                // Ocultar la columna de contraseña si existe
                if (dgvUsuarios.Columns.Contains("Contrasena"))
                {
                    dgvUsuarios.Columns["Contrasena"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (usuarioIdSeleccionado == 0) // Nuevo usuario
                {
                    bool resultado = usuarioDAO.InsertarUsuario(
                        txtNombreUsuario.Text.Trim(),
                        txtContrasena.Text.Trim(),
                        txtNombreCompleto.Text.Trim(),
                        txtEmail.Text.Trim(),
                        cmbRol.Text
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Usuario guardado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
                else // Actualizar usuario
                {
                    bool resultado = usuarioDAO.ActualizarUsuario(
                        usuarioIdSeleccionado,
                        txtNombreUsuario.Text.Trim(),
                        txtNombreCompleto.Text.Trim(),
                        txtEmail.Text.Trim(),
                        cmbRol.Text
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Usuario actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un usuario de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];

                usuarioIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombreUsuario.Text = row.Cells["NombreUsuario"].Value.ToString();
                txtNombreCompleto.Text = row.Cells["NombreCompleto"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cmbRol.Text = row.Cells["Rol"].Value.ToString();

                txtContrasena.Text = ""; // No mostrar contraseña
                txtContrasena.Enabled = false;

                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un usuario de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
                string nombre = dgvUsuarios.SelectedRows[0].Cells["NombreUsuario"].Value.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de eliminar el usuario '{nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    bool eliminado = usuarioDAO.EliminarUsuario(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            usuarioIdSeleccionado = 0;
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            txtNombreCompleto.Clear();
            txtEmail.Clear();
            cmbRol.SelectedIndex = -1;

            txtContrasena.Enabled = true;
            btnGuardar.Text = "Guardar";

            txtNombreUsuario.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Ingrese el nombre de usuario", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text) && usuarioIdSeleccionado == 0)
            {
                MessageBox.Show("Ingrese la contraseña", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("Ingrese el nombre completo", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el email", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }
    }
}