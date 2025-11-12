using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================
// CLASE: Ciudad
// ============================================
public class Ciudad
{
    public int IdCiudad { get; set; }
    public string CodigoCiudad { get; set; }
    public string NombreCiudad { get; set; }
    public string Pais { get; set; }
    public string CodigoAeropuerto { get; set; }
    public string NombreAeropuerto { get; set; }

    public override string ToString()
    {
        return $"{CodigoAeropuerto} - {NombreCiudad}, {Pais}";
    }

    /// <summary>
    /// Retorna el nombre completo con formato
    /// </summary>
    public string ObtenerNombreCompleto()
    {
        return $"{NombreCiudad} ({CodigoAeropuerto}) - {Pais}";
    }
}