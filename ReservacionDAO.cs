using MySql.Data.MySqlClient;
using System;
using System.Data;

public class ReservacionDAO
{
    private ConexionDB conexionDB;

    public ReservacionDAO()
    {
        conexionDB = new ConexionDB();
    }

    // Insertar nueva reservación
    public bool InsertarReservacion(int pasajeroId, int vueloId, string numeroAsiento,
                                   bool equipajeMano, bool equipajeBodega)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            // Generar código de reservación único
            string codigoReservacion = GenerarCodigoReservacion();

            string query = @"INSERT INTO Reservaciones 
                           (PasajeroId, VueloId, CodigoReservacion, NumeroAsiento, 
                           EquipajeMano, EquipajeBodega, Estado) 
                           VALUES (@pasajeroId, @vueloId, @codigo, @asiento, 
                           @equipajeMano, @equipajeBodega, 'Pendiente')";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@pasajeroId", pasajeroId);
            cmd.Parameters.AddWithValue("@vueloId", vueloId);
            cmd.Parameters.AddWithValue("@codigo", codigoReservacion);
            cmd.Parameters.AddWithValue("@asiento", numeroAsiento);
            cmd.Parameters.AddWithValue("@equipajeMano", equipajeMano);
            cmd.Parameters.AddWithValue("@equipajeBodega", equipajeBodega);

            int resultado = cmd.ExecuteNonQuery();

            // Actualizar asientos disponibles del vuelo
            if (resultado > 0)
            {
                ActualizarAsientosDisponibles(vueloId, -1, conexion);
            }

            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar reservación: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Generar código único de reservación
    private string GenerarCodigoReservacion()
    {
        Random random = new Random();
        return $"RES-{DateTime.Now:yyyyMMdd}-{random.Next(1000, 9999)}";
    }

    // Actualizar asientos disponibles
    private void ActualizarAsientosDisponibles(int vueloId, int cantidad, MySqlConnection conexion)
    {
        string query = @"UPDATE Vuelos 
                        SET AsientosDisponibles = AsientosDisponibles + @cantidad 
                        WHERE Id = @vueloId";

        MySqlCommand cmd = new MySqlCommand(query, conexion);
        cmd.Parameters.AddWithValue("@cantidad", cantidad);
        cmd.Parameters.AddWithValue("@vueloId", vueloId);
        cmd.ExecuteNonQuery();
    }

    // Consultar todas las reservaciones
    public DataTable ConsultarReservaciones()
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"SELECT r.Id, r.CodigoReservacion, r.NumeroAsiento, r.Estado,
                           r.FechaReservacion, r.EquipajeMano, r.EquipajeBodega,
                           CONCAT(p.Nombre, ' ', p.Apellido) AS Pasajero,
                           v.NumeroVuelo, v.FechaSalida, v.TarifaBase
                           FROM Reservaciones r
                           INNER JOIN Pasajeros p ON r.PasajeroId = p.Id
                           INNER JOIN Vuelos v ON r.VueloId = v.Id
                           ORDER BY r.FechaReservacion DESC";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar reservaciones: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Consultar reservaciones por pasajero
    public DataTable ConsultarReservacionesPorPasajero(int pasajeroId)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"SELECT r.Id, r.CodigoReservacion, r.NumeroAsiento, r.Estado,
                           v.NumeroVuelo, v.FechaSalida, v.FechaLlegada,
                           rut.CiudadOrigen, rut.CiudadDestino, v.TarifaBase
                           FROM Reservaciones r
                           INNER JOIN Vuelos v ON r.VueloId = v.Id
                           INNER JOIN Rutas rut ON v.RutaId = rut.Id
                           WHERE r.PasajeroId = @pasajeroId
                           ORDER BY v.FechaSalida DESC";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@pasajeroId", pasajeroId);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al consultar reservaciones: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Actualizar estado de reservación
    public bool ActualizarEstadoReservacion(int id, string estado)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = "UPDATE Reservaciones SET Estado = @estado WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@estado", estado);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar reservación: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Cancelar reservación
    public bool CancelarReservacion(int id, string motivo)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            // Obtener el vueloId antes de cancelar
            string queryVuelo = "SELECT VueloId FROM Reservaciones WHERE Id = @id";
            MySqlCommand cmdVuelo = new MySqlCommand(queryVuelo, conexion);
            cmdVuelo.Parameters.AddWithValue("@id", id);
            int vueloId = Convert.ToInt32(cmdVuelo.ExecuteScalar());

            // Actualizar estado de reservación
            string query = "UPDATE Reservaciones SET Estado = 'Cancelada' WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            int resultado = cmd.ExecuteNonQuery();

            // Devolver asiento disponible
            if (resultado > 0)
            {
                ActualizarAsientosDisponibles(vueloId, 1, conexion);

                // Registrar cancelación
                string queryCancelacion = @"INSERT INTO Cancelaciones 
                                          (ReservacionId, MotivoCancelacion) 
                                          VALUES (@reservacionId, @motivo)";
                MySqlCommand cmdCancel = new MySqlCommand(queryCancelacion, conexion);
                cmdCancel.Parameters.AddWithValue("@reservacionId", id);
                cmdCancel.Parameters.AddWithValue("@motivo", motivo);
                cmdCancel.ExecuteNonQuery();
            }

            return resultado > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al cancelar reservación: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }

    // Calcular costo total de reservación
    public decimal CalcularCostoTotal(int reservacionId)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = conexionDB.ObtenerConexion();

            string query = @"SELECT v.TarifaBase, r.EquipajeMano, r.EquipajeBodega
                           FROM Reservaciones r
                           INNER JOIN Vuelos v ON r.VueloId = v.Id
                           WHERE r.Id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", reservacionId);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    decimal tarifaBase = reader.GetDecimal("TarifaBase");
                    bool equipajeMano = reader.GetBoolean("EquipajeMano");
                    bool equipajeBodega = reader.GetBoolean("EquipajeBodega");

                    decimal total = tarifaBase;

                    if (equipajeMano)
                        total += tarifaBase * 0.10m; // 10% adicional

                    if (equipajeBodega)
                        total += tarifaBase * 0.20m; // 20% adicional

                    return total;
                }
            }

            return 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al calcular costo: " + ex.Message);
        }
        finally
        {
            conexionDB.CerrarConexion(conexion);
        }
    }
}