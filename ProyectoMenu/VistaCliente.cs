public class VistaCliente
{
    public void MostrarMenu()
    {
        Console.WriteLine("1. Añadir cliente");
        Console.WriteLine("2. Listar todos los clientes");
        Console.WriteLine("3. Salir");
    }

    public Clientes PedirDatosCliente()
    {
        Console.WriteLine("--- Añadir Nuevo Cliente ---");
        Console.Write("Ingresa el nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingresa el teléfono: ");
        string telefono = Console.ReadLine();
        return new Clientes(nombre, telefono);
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