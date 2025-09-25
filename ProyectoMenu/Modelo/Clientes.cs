public class Clientes
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public Clientes(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
}