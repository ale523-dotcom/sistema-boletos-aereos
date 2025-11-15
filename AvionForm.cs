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
    public partial class AvionForm : Form
    {

        private AvionDAO avionDAO;
        private int avionIdSeleccionado = 0;

        public AvionForm()
        {
            InitializeComponent();
            avionDAO = new AvionDAO();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;

            try
            {

                int pasajeros = (int)numPasajeros.Value;
                int aerolineaId = Convert.ToInt32(cmbAerolinea.SelectedValue);

                Console.WriteLine("ID DE AEROLINEA" + aerolineaId);

                if (avionIdSeleccionado == 0) // Nuevo avion
                {
                    bool resultado = avionDAO.InsertarAvion(

                        aerolineaId,
                        txtModelo.Text.Trim(),
                        txtSerie.Text.Trim(),
                        pasajeros.ToString()
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Avion guardado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAviones();
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
                else // Actualizar avion
                {
                    bool resultado = avionDAO.ActualizarAvion(
                        avionIdSeleccionado,
                        aerolineaId,
                        txtModelo.Text.Trim(),
                        txtSerie.Text.Trim(),
                        pasajeros.ToString()
                    );

                    if (resultado)
                    {
                        MessageBox.Show("Avion actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAviones();
                        CargarAerolineas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar avion: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo del avion", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelo.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtSerie.Text) && avionIdSeleccionado == 0)
            {
                MessageBox.Show("Ingrese el numero de serie", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerie.Focus();
                return false;
            }

            if (numPasajeros.Value <= 0)
            {
                MessageBox.Show("Ingrese el número de pasajeros", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPasajeros.Focus();
                return false;
            }


            if (cmbAerolinea.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una aerolinea", "Campo requerido",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAerolinea.Focus();
                return false;
            }


            return true;
        }





        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAviones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un avión de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvAviones.SelectedRows[0];

                avionIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);

                txtModelo.Text = row.Cells["Modelo"].Value.ToString();
                txtSerie.Text = row.Cells["NumeroSerie"].Value.ToString();
                numPasajeros.Value = Convert.ToDecimal(row.Cells["CapacidadPasajeros"].Value);


                // Selecciona la aerolínea en el ComboBox
                cmbAerolinea.SelectedValue = row.Cells["AerolineaId"].Value;

                btnAgregar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del avión: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void AvionForm_Load(object sender, EventArgs e)
        {
            CargarAviones();
            CargarAerolineas();
        }

        private void dgvAviones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            avionIdSeleccionado = 0;
            txtModelo.Clear();
            txtSerie.Clear();
            cmbAerolinea.SelectedIndex = -1;
            numPasajeros.Value = 0;

            btnAgregar.Text = "Guardar";

            txtModelo.Focus();
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


        private void CargarAviones()
        {
            try
            {
                DataTable dt = avionDAO.ConsultarAviones();
                dgvAviones.DataSource = dt;
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error al cargar los aviones: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
        }

        private void dgvAviones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnModificar_Click(sender, e);
            }
        }
    }
}
