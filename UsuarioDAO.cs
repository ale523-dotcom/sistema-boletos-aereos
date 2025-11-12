using MySql.Data.MySqlClient;
using System;
using System.Data;

public class UsuarioDAO
{
    private ConexionDB conexionDB;

    public UsuarioDAO()
    {
        conexionDB = new ConexionDB();
    }

    // Insertar nuevo usuario
    public bool InsertarUsuario(string nombreUsuario, string contrasena, string nombreCompleto, string email, string rol)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"INSERT INTO Usuarios (NombreUsuario, Contrasena, NombreCompleto, Email, Rol) 
                           VALUES (@usuario, @pass, @nombre, @email, @rol)";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@pass", contrasena);
            cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@rol", rol);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar usuario: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Consultar todos los usuarios
    public DataTable ConsultarUsuarios()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "SELECT Id, NombreUsuario, NombreCompleto, Email, Rol, Activo FROM Usuarios";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar usuarios: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Actualizar usuario
    public bool ActualizarUsuario(int id, string nombreUsuario, string nombreCompleto, string email, string rol)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE Usuarios 
                       SET NombreUsuario = @usuario, NombreCompleto = @nombre, Email = @email, Rol = @rol 
                       WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@rol", rol);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar usuario: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Eliminar usuario (desactivar)
    public bool EliminarUsuario(int id)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "UPDATE Usuarios SET Activo = FALSE WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar usuario: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }
}