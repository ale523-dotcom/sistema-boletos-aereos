using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================
// CLASE: Ruta
// ============================================
public class Ruta
{
    public int IdRuta { get; set; }
    public int IdCiudadOrigen { get; set; }
    public int IdCiudadDestino { get; set; }
    public decimal DistanciaKm { get; set; }
    public TimeSpan DuracionEstimada { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }

    // Información de las ciudades (para mostrar)
    public string CiudadOrigen { get; set; }
    public string CodigoOrigen { get; set; }
    public string CiudadDestino { get; set; }
    public string CodigoDestino { get; set; }

    public Ruta()
    {
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{CodigoOrigen} → {CodigoDestino}";
    }

    /// <summary>
    /// Obtiene la descripción completa de la ruta
    /// </summary>
    public string ObtenerDescripcionCompleta()
    {
        return $"{CiudadOrigen} ({CodigoOrigen}) → {CiudadDestino} ({CodigoDestino}) - {DistanciaKm:N0} km";
    }
}