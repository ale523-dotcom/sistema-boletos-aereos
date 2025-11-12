using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================
// CLASE: Vuelo
// ============================================
public class Vuelo
{
    public int IdVuelo { get; set; }
    public string NumeroVuelo { get; set; }
    public int IdAerolinea { get; set; }
    public int IdAvion { get; set; }
    public int IdRuta { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime FechaLlegada { get; set; }
    public decimal PrecioBase { get; set; }
    public int AsientosDisponibles { get; set; }
    public string Estado { get; set; } // Programado, En vuelo, Completado, Cancelado, Retrasado
    public string PuertaEmbarque { get; set; }
    public string Terminal { get; set; }
    public DateTime FechaRegistro { get; set; }

    // Información relacionada (para mostrar)
    public string NombreAerolinea { get; set; }
    public string CodigoAerolinea { get; set; }
    public string ModeloAvion { get; set; }
    public string CiudadOrigen { get; set; }
    public string CodigoOrigen { get; set; }
    public string CiudadDestino { get; set; }
    public string CodigoDestino { get; set; }
    public TimeSpan DuracionVuelo { get; set; }

    public Vuelo()
    {
        Estado = "Programado";
        FechaRegistro = DateTime.Now;
    }

    /// <summary>
    /// Verifica si el vuelo tiene asientos disponibles
    /// </summary>
    public bool TieneAsientosDisponibles()
    {
        return AsientosDisponibles > 0 && Estado == "Programado";
    }

    /// <summary>
    /// Calcula la duración del vuelo
    /// </summary>
    public TimeSpan CalcularDuracion()
    {
        return FechaLlegada - FechaSalida;
    }

    /// <summary>
    /// Obtiene información resumida del vuelo
    /// </summary>
    public string ObtenerResumen()
    {
        return $"{NumeroVuelo} | {CiudadOrigen} → {CiudadDestino} | {FechaSalida:dd/MM HH:mm} | ${PrecioBase:N2}";
    }

    public override string ToString()
    {
        return $"{NumeroVuelo} - {CodigoOrigen} → {CodigoDestino}";
    }
}