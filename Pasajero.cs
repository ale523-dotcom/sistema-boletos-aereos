using System;
using System.Collections.Generic;

// ============================================
// CLASE: Pasajero (hereda de Persona)
// ============================================
public class Pasajero : Persona
{
    public DateTime FechaNacimiento { get; set; }
    // ... otras propiedades que tengas

    // Método para calcular la edad
    public int CalcularEdad()
    {
        var hoy = DateTime.Today;
        var edad = hoy.Year - FechaNacimiento.Year;

        // Ajustar si aún no ha cumplido años este año
        if (FechaNacimiento.Date > hoy.AddYears(-edad))
        {
            edad--;
        }

        return edad;
    }

    // El método que está llamando a CalcularEdad()
    public bool EsMayorDeEdad()
    {
        return CalcularEdad() >= 18;
    }

    public override string ObtenerInformacion()
    {
        return base.ObtenerInformacion() + $" - Edad: {CalcularEdad()}";
    }
}