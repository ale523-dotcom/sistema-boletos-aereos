using MySql.Data.MySqlClient;
using System;
using System.Data;

public class PasajeroDAO
{
    private ConexionDB conexionDB;

    public PasajeroDAO()
    {
        conexionDB = new ConexionDB();
    }

    // Insertar nuevo pasajero - CORREGIDO
    public bool InsertarPasajero(string nombre, string apellido, DateTime fechaNacimiento,
                                 string numeroPasaporte, string nacionalidad, string email, string telefono)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            // ⚠️ ESTE ERA EL ERROR - La consulta SELECT estaba en lugar del INSERT
            string query = @"INSERT INTO Pasajeros (Nombre, Apellido, FechaNacimiento, 
                            NumeroPasaporte, Nacionalidad, Email, Telefono) 
                            VALUES (@nombre, @apellido, @fechaNacimiento, @numeroPasaporte, 
                            @nacionalidad, @email, @telefono)";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.Date).Value = fechaNacimiento.Date;
            cmd.Parameters.AddWithValue("@numeroPasaporte", numeroPasaporte);
            cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telefono", telefono);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar el pasajero: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Consultar todos los pasajeros
    public DataTable ConsultarPasajeros()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"SELECT Id, Nombre, Apellido, FechaNacimiento, 
                            NumeroPasaporte, Nacionalidad, Email, Telefono 
                            FROM Pasajeros";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar pasajeros: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Actualizar pasajero
    public bool ActualizarPasajero(int id, string nombre, string apellido, DateTime fechaNacimiento,
                                   string numeroPasaporte, string nacionalidad, string email, string telefono)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE Pasajeros 
                            SET Nombre = @nombre, Apellido = @apellido, 
                            FechaNacimiento = @fechaNacimiento, NumeroPasaporte = @numeroPasaporte, 
                            Nacionalidad = @nacionalidad, Email = @email, Telefono = @telefono
                            WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.Date).Value = fechaNacimiento.Date;
            cmd.Parameters.AddWithValue("@numeroPasaporte", numeroPasaporte);
            cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telefono", telefono);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar pasajero: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }
}