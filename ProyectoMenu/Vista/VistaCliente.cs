public class VistaCliente
{
    public void MostrarMenu()
    {
        Console.WriteLine("1. Añadir cliente");
        Console.WriteLine("2. Listar todos los clientes");
        Console.WriteLine("3. Salir");
    }

    public void AnadirCliente()
    {
        Console.Write("\nCliente añadido");
    }
    public void PedirNombre()
    {
        Console.Write("Ingresa el nombre: ");
    }
    public void PedirTelefono()
    {
        Console.Write("Ingresa el teléfono: ");
    }

    public void MostrarListaClientes(List<Clientes> clientes)
    {
        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados.");
        }
        else
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}, Teléfono: {cliente.Telefono}");
            }
        }
    }
}