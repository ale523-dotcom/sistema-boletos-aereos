using MySql.Data.MySqlClient;
using System;

public class ConexionDB
{
    private string connectionString;

    public ConexionDB()
    {
        // Modifique estos valores con tu configuración
        connectionString = "Server=localhost;Database=boletos_aereos;Uid=root;Pwd=alex200330;";
    }

    public MySqlConnection ObtenerConexion()
    {
        try
        {
            MySqlConnection conexion = new MySqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al conectar con la base de datos: " + ex.Message);
        }
    }

    public void CerrarConexion(MySqlConnection conexion)
    {
        if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
        {
            conexion.Close();
        }
    }
}