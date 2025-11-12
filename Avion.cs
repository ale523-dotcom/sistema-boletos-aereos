using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

     // ============================================
    // CLASE: Avion
    // ============================================
public class Avion
{
    public int IdAvion { get; set; }
    public int IdAerolinea { get; set; }
    public string CodigoAvion { get; set; }
    public string Modelo { get; set; }
    public string Fabricante { get; set; }
    public int CapacidadPasajeros { get; set; }
    public int CapacidadEquipaje { get; set; }
    public int AnioFabricacion { get; set; }
    public string Estado { get; set; } // Activo, Mantenimiento, Inactivo
    public DateTime FechaRegistro { get; set; }

    // Relación con Aerolínea
    public string NombreAerolinea { get; set; }

    public Avion()
    {
        Estado = "Activo";
        FechaRegistro = DateTime.Now;
    }

    /// <summary>
    /// Verifica si el avión está disponible para vuelos
    /// </summary>
    public bool EstaDisponible()
    {
        return Estado == "Activo";
    }

    public override string ToString()
    {
        return $"{CodigoAvion} - {Modelo} ({CapacidadPasajeros} asientos)";
    }
}