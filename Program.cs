using System;
using System.Windows.Forms;

namespace Sistema_de_Boletos_Aéreos
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // CAMBIA AQUÍ: Ahora inicia con el Dashboard en lugar de Form1
            Application.Run(new DashboardForm());
        }
    }
}