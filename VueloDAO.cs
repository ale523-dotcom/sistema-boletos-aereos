using MySql.Data.MySqlClient;
using System;
using System.Data;

public class VueloDAO
{
    private ConexionDB conexionDB;

    public VueloDAO()
    {
        conexionDB = new ConexionDB();
    }

    // Insertar nuevo vuelo
    public bool InsertarVuelo(string numeroVuelo, int aerolineaId, int rutaId, int avionId,
                             DateTime fechaSalida, DateTime fechaLlegada, decimal tarifaBase, int asientosDisponibles)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"INSERT INTO Vuelos (NumeroVuelo, AerolineaId, RutaId, AvionId, 
                           FechaSalida, FechaLlegada, TarifaBase, AsientosDisponibles, Estado) 
                           VALUES (@numeroVuelo, @aerolineaId, @rutaId, @avionId, 
                           @fechaSalida, @fechaLlegada, @tarifaBase, @asientosDisponibles, 'Programado')";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@numeroVuelo", numeroVuelo);
            cmd.Parameters.AddWithValue("@aerolineaId", aerolineaId);
            cmd.Parameters.AddWithValue("@rutaId", rutaId);
            cmd.Parameters.AddWithValue("@avionId", avionId);
            cmd.Parameters.AddWithValue("@fechaSalida", fechaSalida);
            cmd.Parameters.AddWithValue("@fechaLlegada", fechaLlegada);
            cmd.Parameters.AddWithValue("@tarifaBase", tarifaBase);
            cmd.Parameters.AddWithValue("@asientosDisponibles", asientosDisponibles);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar vuelo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Consultar todos los vuelos
    public DataTable ConsultarVuelos()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"SELECT v.Id, v.NumeroVuelo, v.AerolineaId, v.RutaId, v.AvionId,
                           v.FechaSalida, v.FechaLlegada, v.TarifaBase, v.AsientosDisponibles, v.Estado,
                           a.Nombre AS Aerolinea, r.CiudadOrigen, r.CiudadDestino
                           FROM Vuelos v
                           INNER JOIN Aerolineas a ON v.AerolineaId = a.Id
                           INNER JOIN Rutas r ON v.RutaId = r.Id";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar vuelos: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Actualizar vuelo
    public bool ActualizarVuelo(int id, string numeroVuelo, int aerolineaId, int rutaId, int avionId,
                               DateTime fechaSalida, DateTime fechaLlegada, decimal tarifaBase,
                               int asientosDisponibles, string estado)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"UPDATE Vuelos 
                           SET NumeroVuelo = @numeroVuelo, AerolineaId = @aerolineaId, 
                           RutaId = @rutaId, AvionId = @avionId, FechaSalida = @fechaSalida,
                           FechaLlegada = @fechaLlegada, TarifaBase = @tarifaBase, 
                           AsientosDisponibles = @asientosDisponibles, Estado = @estado
                           WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@numeroVuelo", numeroVuelo);
            cmd.Parameters.AddWithValue("@aerolineaId", aerolineaId);
            cmd.Parameters.AddWithValue("@rutaId", rutaId);
            cmd.Parameters.AddWithValue("@avionId", avionId);
            cmd.Parameters.AddWithValue("@fechaSalida", fechaSalida);
            cmd.Parameters.AddWithValue("@fechaLlegada", fechaLlegada);
            cmd.Parameters.AddWithValue("@tarifaBase", tarifaBase);
            cmd.Parameters.AddWithValue("@asientosDisponibles", asientosDisponibles);
            cmd.Parameters.AddWithValue("@estado", estado);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar vuelo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Cancelar vuelo
    public bool CancelarVuelo(int id)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "UPDATE Vuelos SET Estado = 'Cancelado' WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al cancelar vuelo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Buscar vuelos disponibles
    public DataTable BuscarVuelosDisponibles(string ciudadOrigen, string ciudadDestino, DateTime fecha)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"SELECT v.Id, v.NumeroVuelo, v.FechaSalida, v.FechaLlegada, 
                           v.TarifaBase, v.AsientosDisponibles, a.Nombre AS Aerolinea,
                           r.CiudadOrigen, r.CiudadDestino
                           FROM Vuelos v
                           INNER JOIN Aerolineas a ON v.AerolineaId = a.Id
                           INNER JOIN Rutas r ON v.RutaId = r.Id
                           WHERE r.CiudadOrigen = @origen 
                           AND r.CiudadDestino = @destino
                           AND DATE(v.FechaSalida) = DATE(@fecha)
                           AND v.AsientosDisponibles > 0
                           AND v.Estado = 'Programado'";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@origen", ciudadOrigen);
            cmd.Parameters.AddWithValue("@destino", ciudadDestino);
            cmd.Parameters.AddWithValue("@fecha", fecha.Date);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al buscar vuelos: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }
}