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
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Configuraciones adicionales al cargar
            this.Text = "Sistema de Boletos Aéreos - Dashboard";

            // Aplicar estilos a todos los botones
            AplicarEstilosModernos();
        }

        private void AplicarEstilosModernos()
        {
            // Aplicar bordes redondeados y sombras a los paneles
            panelOperaciones.Paint += Panel_Paint;
            panelCatalogos.Paint += Panel_Paint;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar sombra suave en los paneles
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (var pen = new Pen(Color.FromArgb(30, 0, 0, 0), 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        // ===== EFECTOS HOVER CON ANIMACIÓN =====
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Guardar color original
                btn.Tag = btn.BackColor;

                // Cambiar a color más brillante y aumentar tamaño de fuente
                btn.BackColor = AjustarBrillo(btn.BackColor, 30);
                btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size + 1, btn.Font.Style);

                // Cambiar cursor
                btn.Cursor = Cursors.Hand;
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                // Restaurar color original
                btn.BackColor = (Color)btn.Tag;
                btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size - 1, btn.Font.Style);
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

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}