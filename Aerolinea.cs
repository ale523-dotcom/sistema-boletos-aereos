using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================
// CLASE: Aerolinea
// ============================================
public class Aerolinea
{
    public int IdAerolinea { get; set; }
    public string CodigoAerolinea { get; set; }
    public string Nombre { get; set; }
    public string PaisOrigen { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string SitioWeb { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }

    public Aerolinea()
    {
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{CodigoAerolinea} - {Nombre}";
    }
}