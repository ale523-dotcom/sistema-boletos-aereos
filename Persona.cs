public class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Identificacion { get; set; }

    // Método virtual para que pueda ser sobrescrito
    public virtual string ObtenerInformacion()
    {
        return $"{Nombre} {Apellido} - ID: {Identificacion}";
    }
}