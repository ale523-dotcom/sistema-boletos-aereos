using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RutaDAO
{
    private ConexionDB conexionDB;


    public RutaDAO()
    {
        conexionDB = new ConexionDB();
    }


    // Insertar nueva ruta
    public bool InsertarRuta(string ciudadOrigen, string ciudadDestino, decimal distancia, string duracionEstimada)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"INSERT INTO Rutas (CiudadOrigen, CiudadDestino, Distancia, DuracionEstimada) 
                           VALUES (@ciudadOrigen, @ciudadDestino, @distancia, @duracionEstimada)";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@ciudadOrigen", ciudadOrigen);
            cmd.Parameters.AddWithValue("@ciudadDestino", ciudadDestino);
            cmd.Parameters.AddWithValue("@distancia", distancia);
            cmd.Parameters.AddWithValue("@duracionEstimada", duracionEstimada);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar la ruta: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


    // Consultar todos las rutas
    public DataTable ConsultarRutas()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "SELECT Id, CiudadOrigen, CiudadDestino, Distancia, DuracionEstimada, Activo FROM Rutas";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar las rutas: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }



    // Actualizar rutas
    public bool ActualizarRutas(int id, string ciudadOrigen, string ciudadDestino, decimal distancia, string duracionEstimada)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE Rutas 
                       SET CiudadOrigen = @ciudadOrigen, CiudadDestino = @ciudadDestino, Distancia = @distancia, DuracionEstimada = @duracionEstimada 
                       WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ciudadOrigen", ciudadOrigen);
            cmd.Parameters.AddWithValue("@ciudadDestino", ciudadDestino);
            cmd.Parameters.AddWithValue("@distancia", distancia);
            cmd.Parameters.AddWithValue("@duracionEstimada", duracionEstimada);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar la ruta: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }



    // Eliminar rutas (desactivar)
    public bool EliminarRuta(int id)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "UPDATE Rutas SET Activo = FALSE WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar la ruta: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


}