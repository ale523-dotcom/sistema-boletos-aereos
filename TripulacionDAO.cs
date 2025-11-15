using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TripulacionDAO
{

    private ConexionDB conexionDB;

    public TripulacionDAO()
    {
        conexionDB = new ConexionDB();
    }

    // Insertar nueva tripulacion
    public bool InsertarTripulacion(string nombre, string apellido, string identificacion, string cargo, int aerolineaId, DateTime fechaContratacion)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"INSERT INTO Tripulacion (Nombre, Apellido, Identificacion, Cargo, AerolineaId, FechaContratacion) 
                           VALUES (@nombre, @apellido, @identificacion, @cargo, @aerolineaId, @fechaContratacion)";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@identificacion", identificacion);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@aerolineaId", aerolineaId);
            cmd.Parameters.Add("@fechaContratacion", MySqlDbType.Date).Value = fechaContratacion.Date;

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar el tripulante: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }





    // Consultar todos los tripulantes
    public DataTable ConsultarTripulantes()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "SELECT Id, Nombre, Apellido, Identificacion, Cargo, AerolineaId, FechaContratacion, Activo FROM Tripulacion";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar los tripulantes: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }


    // Actualizar tripulante
    public bool ActualizarTripulante(int id, string nombre, string apellido, string identificacion, string cargo, int aerolineaId, DateTime fechaContratacion)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE Tripulante 
                       SET Nombre = @nombre, Apellido = @apellido, Identificacion = @identificacion, Cargo = @cargo, AerolineaId=@aerolineaId, FechaContratacion=@fechaContratacion 
                       WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@identificacion", identificacion);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@aerolineaId", aerolineaId);
            cmd.Parameters.Add("@fechaContratacion", MySqlDbType.Date).Value = fechaContratacion.Date;

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el tripulante: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }



    // Eliminar tripulacion (desactivar)
    public bool EliminarTripulacion(int id)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "UPDATE Tripulacion SET Activo = FALSE WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar la tripulacion: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }



}
