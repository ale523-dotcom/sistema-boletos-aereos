using System;
using System.Collections.Generic;
     // ============================================
    // CLASE: Tripulacion (hereda de Persona)
    // ============================================
public class Tripulacion : Persona
{
    public int IdTripulacion { get; set; }
    public string NumeroLicencia { get; set; }
    public string TipoTripulacion { get; set; } // Piloto, Copiloto, Azafata, Sobrecargo
    public int IdAerolinea { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }

    public Tripulacion()
    {
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public override string ObtenerInformacion()
    {
        return $"{base.ObtenerInformacion()} - {TipoTripulacion} - Lic: {NumeroLicencia}";
    }

    /// <summary>
    /// Verifica si es piloto o copiloto
    /// </summary>
    public bool EsPiloto()
    {
        return TipoTripulacion == "Piloto" || TipoTripulacion == "Copiloto";
    }
}