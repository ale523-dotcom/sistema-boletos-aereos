using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AvionDAO
{

    private ConexionDB conexionDB;

    public AvionDAO()
    {
        conexionDB = new ConexionDB();
    }



    // Insertar una nuevo  avion
    public bool InsertarAvion(int aerolineaId, string modelo, string serie, string numPasajeros)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"INSERT INTO Aviones (AerolineaId, Modelo, NumeroSerie, CapacidadPasajeros) 
                           VALUES (@aerolineaId, @modelo, @serie, @numPasajeros)";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@aerolineaId", aerolineaId);
            cmd.Parameters.AddWithValue("@modelo", modelo);
            cmd.Parameters.AddWithValue("@serie", serie);
            cmd.Parameters.AddWithValue("@numPasajeros", numPasajeros);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar el avión: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


    // Consultar todos los aviones
    public DataTable ConsultarAviones()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "SELECT Id, AerolineaId, Modelo, NumeroSerie, CapacidadPasajeros, Activo FROM Aviones";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar los aviones: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }



    // Actualizar avion
    public bool ActualizarAvion(int id, int aerolineaId, string modelo, string numeroSerie, string numPasajeros)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE Aviones 
                       SET AerolineaId = @aerolineaId, Modelo = @modelo, NumeroSerie = @numeroSerie, CapacidadPasajeros = @numPasajeros 
                       WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@aerolineaId", aerolineaId);
            cmd.Parameters.AddWithValue("@modelo", modelo);
            cmd.Parameters.AddWithValue("@numeroSerie", numeroSerie);
            cmd.Parameters.AddWithValue("@numPasajeros", numPasajeros);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el avión: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }




    // Eliminar avion (desactivar)
    public bool EliminarAvion(int id)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "UPDATE Aviones SET Activo = FALSE WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el avión: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


}
