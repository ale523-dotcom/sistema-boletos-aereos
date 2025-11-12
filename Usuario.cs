
using System;
using System.Collections.Generic;

// ============================================
// CLASE: Usuario (hereda de Persona)
// ============================================
public class Usuario : Persona
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public string TipoUsuario { get; set; } // Administrador, Agente, Cliente
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime? UltimoAcceso { get; set; }

    public Usuario()
    {
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public override string ObtenerInformacion()
    {
        return $"{base.ObtenerInformacion()} - Tipo: {TipoUsuario}";
    }

    /// <summary>
    /// Verifica si el usuario tiene permisos de administrador
    /// </summary>
    public bool EsAdministrador()
    {
        return TipoUsuario == "Administrador";
    }

    /// <summary>
    /// Verifica si el usuario es un agente de ventas
    /// </summary>
    public bool EsAgente()
    {
        return TipoUsuario == "Agente";
    }
}