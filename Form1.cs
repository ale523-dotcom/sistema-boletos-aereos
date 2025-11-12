using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // ⬅️ Importante agregar esta línea

namespace Sistema_de_Boletos_Aéreos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnprobar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionDB conexionDB = new ConexionDB();
                MySqlConnection conexion = conexionDB.ObtenerConexion();

                MessageBox.Show("¡Conexión exitosa! ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conexionDB.CerrarConexion(conexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.ShowDialog();
        }

        private void btnGestionUsuarios_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
