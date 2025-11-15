using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Boletos_Aéreos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PersonalizarFormulario();
        }

        private void PersonalizarFormulario()
        {
            // Configuración del formulario principal
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Font = new Font("Segoe UI", 9F);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código de inicialización
        }

        private void btnprobar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionDB conexionDB = new ConexionDB();
                var conexion = conexionDB.ObtenerConexion();

                MessageBox.Show("¡Conexión exitosa! ✅", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                conexionDB.CerrarConexion(conexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormUsuarios());
        }

        private void btnGestionAerolineas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AerolineasForm());
        }

        private void btnGestionarPasajero_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PasajerosForm());
        }

        private void btnGestionarRutas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new RutasForm());
        }

        private void btnGestionarAviones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AvionForm());
        }

        private void btnGestionarTripulacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new TripulacionForm());
        }

        // Método helper para abrir formularios
        private void AbrirFormulario(Form formulario)
        {
            formulario.ShowDialog();
        }

        // Método para estilizar botones
        private void EstilizarBoton(Button btn, Color colorFondo, Color colorTexto)
        {
            btn.BackColor = colorFondo;
            btn.ForeColor = colorTexto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 45;

            // Efecto hover
            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Light(colorFondo, 0.1f);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = colorFondo;
            };
        }

        private void btnVuelos_Click(object sender, EventArgs e)
        {

        }
    }
}