using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Sistema_de_Boletos_Aéreos
{
    public partial class ReservacionForm : Form
    {
        private ReservacionDAO reservacionDAO;
        private VueloDAO vueloDAO;
        private decimal tarifaBaseActual = 0;

        public ReservacionForm()
        {
            InitializeComponent();
            reservacionDAO = new ReservacionDAO();
            vueloDAO = new VueloDAO();
        }

        private void ReservacionForm_Load(object sender, EventArgs e)
        {
            CargarReservaciones();
            CargarPasajeros();
            ConfigurarDataGridView();
            LimpiarCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvReservaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservaciones.MultiSelect = false;
            dgvReservaciones.ReadOnly = true;
        }

        private void CargarReservaciones()
        {
            try
            {
                DataTable dt = reservacionDAO.ConsultarReservaciones();
                dgvReservaciones.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservaciones: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPasajeros()
        {
            try
            {
                PasajeroDAO pasajero = new PasajeroDAO();
                DataTable dt = pasajero.ConsultarPasajeros();

                dt.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellido");

                cmbPasajero.DataSource = dt;
                cmbPasajero.DisplayMember = "NombreCompleto";
                cmbPasajero.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pasajeros: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrigen.Text) || string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MessageBox.Show("Ingrese ciudad de origen y destino", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = vueloDAO.BuscarVuelosDisponibles(
                    txtOrigen.Text.Trim(),
                    txtDestino.Text.Trim(),
                    dtpFechaVuelo.Value
                );

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron vuelos disponibles para la fecha y ruta seleccionada",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVuelo.DataSource = null;
                    return;
                }

                dt.Columns.Add("DescripcionVuelo", typeof(string),
                    "NumeroVuelo + ' - ' + Convert(FechaSalida, 'System.String') + ' ($' + Convert(TarifaBase, 'System.String') + ')'");

                cmbVuelo.DataSource = dt;
                cmbVuelo.DisplayMember = "DescripcionVuelo";
                cmbVuelo.ValueMember = "Id";

                MessageBox.Show($"Se encontraron {dt.Rows.Count} vuelo(s) disponible(s)", "Búsqueda exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar vuelos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbVuelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVuelo.SelectedIndex >= 0)
            {
                try
                {
                    DataRowView row = (DataRowView)cmbVuelo.SelectedItem;
                    tarifaBaseActual = Convert.ToDecimal(row["TarifaBase"]);
                    CalcularTotal();
                }
                catch { }
            }
        }

        private void chkEquipaje_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = tarifaBaseActual;

            if (chkEquipajeMano.Checked)
                total += tarifaBaseActual * 0.10m;

            if (chkEquipajeBodega.Checked)
                total += tarifaBaseActual * 0.20m;

            lblTotal.Text = $"${total:N2}";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                int pasajeroId = Convert.ToInt32(cmbPasajero.SelectedValue);
                int vueloId = Convert.ToInt32(cmbVuelo.SelectedValue);

                bool resultado = reservacionDAO.InsertarReservacion(
                    pasajeroId,
                    vueloId,
                    txtNumeroAsiento.Text.Trim(),
                    chkEquipajeMano.Checked,
                    chkEquipajeBodega.Checked
                );

                if (resultado)
                {
                    MessageBox.Show($"Reservación guardada exitosamente!\nTotal a pagar: {lblTotal.Text}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarReservaciones();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar reservación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbPasajero.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un pasajero", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPasajero.Focus();
                return false;
            }

            if (cmbVuelo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un vuelo", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVuelo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroAsiento.Text))
            {
                MessageBox.Show("Ingrese el número de asiento", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroAsiento.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvReservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una reservación de la lista", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvReservaciones.SelectedRows[0].Cells["Id"].Value);
                string codigo = dgvReservaciones.SelectedRows[0].Cells["CodigoReservacion"].Value.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de cancelar la reservación '{codigo}'?",
                    "Confirmar cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    string motivo ="Cancelación solicitada por el cliente"; 
                    Form inputForm = new Form
                    {
                        Width = 400,
                        Height = 150,
                        Text = "Motivo de Cancelación",
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    Label label = new Label { Left = 10, Top = 20, Width = 350, Text = "Ingrese el motivo de la cancelación:" };
                    TextBox textBox = new TextBox { Left = 10, Top = 50, Width = 350, Text = motivo };
                    Button btnOk = new Button { Text = "Aceptar", Left = 280, Top = 80, Width = 80, DialogResult = DialogResult.OK };

                    inputForm.Controls.Add(label);
                    inputForm.Controls.Add(textBox);
                    inputForm.Controls.Add(btnOk);
                    inputForm.AcceptButton = btnOk;

                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        motivo = textBox.Text;
                    }
                    inputForm.Dispose();

                    if (!string.IsNullOrWhiteSpace(motivo))
                    {
                        bool cancelado = reservacionDAO.CancelarReservacion(id, motivo);

                        if (cancelado)
                        {
                            MessageBox.Show("Reservación cancelada exitosamente!", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarReservaciones();
                            LimpiarCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar reservación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbPasajero.SelectedIndex = -1;
            cmbVuelo.DataSource = null;
            txtOrigen.Clear();
            txtDestino.Clear();
            dtpFechaVuelo.Value = DateTime.Now;
            txtNumeroAsiento.Clear();
            chkEquipajeMano.Checked = false;
            chkEquipajeBodega.Checked = false;
            tarifaBaseActual = 0;
            lblTotal.Text = "$0.00";

            txtOrigen.Focus();
        }
    }
}