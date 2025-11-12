using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================
// CLASE: Reservacion
// ============================================
public class Reservacion
{
    public int IdReservacion { get; set; }
    public string CodigoReservacion { get; set; }
    public int IdVuelo { get; set; }
    public int IdPasajero { get; set; }
    public int IdUsuario { get; set; }
    public string NumeroAsiento { get; set; }
    public string Clase { get; set; } // Economica, Ejecutiva, Primera Clase
    public bool EquipajeMano { get; set; }
    public bool EquipajeBodega { get; set; }
    public decimal PrecioVuelo { get; set; }
    public decimal CargoEquipaje { get; set; }
    public decimal PrecioTotal { get; set; }
    public string Estado { get; set; } // Pendiente, Confirmada, Cancelada, Completada
    public DateTime FechaReservacion { get; set; }
    public DateTime? FechaCancelacion { get; set; }
    public string MotivoCancelacion { get; set; }

    // Información relacionada
    public string NumeroVuelo { get; set; }
    public string NombreAerolinea { get; set; }
    public string CiudadOrigen { get; set; }
    public string CiudadDestino { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime FechaLlegada { get; set; }
    public string NombrePasajero { get; set; }
    public string NumeroPasaporte { get; set; }

    public Reservacion()
    {
        CodigoReservacion = GenerarCodigoReservacion();
        Estado = "Pendiente";
        FechaReservacion = DateTime.Now;
        CargoEquipaje = 0;
    }

    /// <summary>
    /// Genera un código único de reservación
    /// </summary>
    private string GenerarCodigoReservacion()
    {
        Random random = new Random();
        return $"RES-{random.Next(100000, 999999)}";
    }

    /// <summary>
    /// Calcula el precio total incluyendo cargos por equipaje
    /// </summary>
    public void CalcularPrecioTotal()
    {
        CargoEquipaje = 0;

        if (EquipajeMano)
            CargoEquipaje += PrecioVuelo * 0.10m; // 10% por equipaje de mano

        if (EquipajeBodega)
            CargoEquipaje += PrecioVuelo * 0.20m; // 20% por equipaje de bodega

        PrecioTotal = PrecioVuelo + CargoEquipaje;
    }

    /// <summary>
    /// Verifica si la reservación puede ser cancelada
    /// </summary>
    public bool PuedeCancelarse()
    {
        return Estado == "Pendiente" || Estado == "Confirmada";
    }

    /// <summary>
    /// Obtiene un resumen de la reservación
    /// </summary>
    public string ObtenerResumen()
    {
        return $"{CodigoReservacion} | {NumeroVuelo} | {CiudadOrigen}-{CiudadDestino} | ${PrecioTotal:N2}";
    }

    public override string ToString()
    {
        return $"{CodigoReservacion} - {Estado}";
    }
}