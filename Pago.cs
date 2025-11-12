using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================
// CLASE: Pago
// ============================================
public class Pago
{
    public int IdPago { get; set; }
    public int IdReservacion { get; set; }
    public string MetodoPago { get; set; } // Efectivo, Tarjeta Credito, Tarjeta Debito, Transferencia
    public decimal Monto { get; set; }
    public string NumeroReferencia { get; set; }
    public string NumeroAutorizacion { get; set; }
    public string EstadoPago { get; set; } // Pendiente, Aprobado, Rechazado, Reembolsado
    public DateTime FechaPago { get; set; }

    public Pago()
    {
        EstadoPago = "Pendiente";
        FechaPago = DateTime.Now;
        NumeroReferencia = GenerarReferencia();
    }

    /// <summary>
    /// Genera un número de referencia único
    /// </summary>
    private string GenerarReferencia()
    {
        return $"PAG-{DateTime.Now:yyyyMMddHHmmss}";
    }

    /// <summary>
    /// Verifica si el pago fue aprobado
    /// </summary>
    public bool FueAprobado()
    {
        return EstadoPago == "Aprobado";
    }

    /// <summary>
    /// Procesa el pago (simulación)
    /// </summary>
    public bool ProcesarPago()
    {
        // En un sistema real, aquí se conectaría con una pasarela de pago
        // Por ahora simulamos una aprobación automática
        Random random = new Random();
        bool aprobado = random.Next(1, 11) > 2; // 80% de aprobación

        if (aprobado)
        {
            EstadoPago = "Aprobado";
            NumeroAutorizacion = $"AUTH-{random.Next(100000, 999999)}";
        }
        else
        {
            EstadoPago = "Rechazado";
        }

        return aprobado;
    }

    public override string ToString()
    {
        return $"{NumeroReferencia} - {MetodoPago} - ${Monto:N2}";
    }
}