using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TripulacionVueloDAO
{

    private ConexionDB conexionDB;


    public TripulacionVueloDAO()
    {
        conexionDB = new ConexionDB();
    }



    // Insertar nuevo tripulacion de vuelo
    public bool InsertarTripulacionVuelo(int idVuelo, int idTripulacion)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"INSERT INTO TripulacionVuelo (VueloId, TripulacionId) 
                           VALUES (@idVuelo, @idTripulacion)";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@idVuelo", idVuelo);
            cmd.Parameters.AddWithValue("@idTripulacion", idTripulacion);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar la tripulacion del vuelo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


    // Consultar todos los tripulacion vuelo
    public DataTable ConsultarTripulacionVuelo()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "SELECT Id, VueloId, TripulacionId FROM TripulacionVuelo";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar Tripulacion vuelo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


    // Actualizar tripulacion vuelo
    public bool ActualizarTripulacionVuelo(int id, int idVuelo, int idTripulacion)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE TripulacionVuelo 
                       SET VueloId = @idVuelo, TripulacionId = @idTripulacion 
                       WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@idVuelo", idVuelo);
            cmd.Parameters.AddWithValue("@idTripulacion", idTripulacion);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar la tripulacion vuelo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }




}
