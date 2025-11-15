using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Boletos_Aéreos
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            PersonalizarBotones();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Configuraciones adicionales al cargar
            this.Text = "Sistema de Boletos Aéreos - Dashboard";
        }

        private void PersonalizarBotones()
        {
            // Efecto hover para todos los botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.MouseEnter += (s, e) =>
                    {
                        btn.BackColor = AjustarBrillo(btn.BackColor, -30);
                        btn.Cursor = Cursors.Hand;
                    };
                    btn.MouseLeave += (s, e) =>
                    {
                        btn.BackColor = AjustarBrillo(btn.BackColor, 30);
                    };
                }
            }
        }

        private Color AjustarBrillo(Color color, int cantidad)
        {
            int r = Math.Max(0, Math.Min(255, color.R + cantidad));
            int g = Math.Max(0, Math.Min(255, color.G + cantidad));
            int b = Math.Max(0, Math.Min(255, color.B + cantidad));
            return Color.FromArgb(color.A, r, g, b);
        }

        // ===== EVENTOS DE LOS BOTONES =====

        private void btnReservaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PasajerosForm(), "Gestión de Pasajeros");
        }

        private void btnVuelos_Click(object sender, EventArgs e)
        {
                AbrirFormulario(new VueloForm(), "Gestión de Vuelos");
        }

        private void btnTripulacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new TripulacionVueloForm(), "Asignación de Tripulación");
        }

        private void btnAerolineas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AerolineasForm(), "Gestión de Aerolíneas");
        }

        private void btnAviones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AvionForm(), "Gestión de Aviones");
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new RutasForm(), "Gestión de Rutas");
        }

        private void btnTripulantes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new TripulacionForm(), "Gestión de Tripulantes");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormUsuarios(), "Gestión de Usuarios");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ===== MÉTODO AUXILIAR =====

        private void AbrirFormulario(Form formulario, string titulo)
        {
            try
            {
                formulario.Text = titulo;
                formulario.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}