public class ControladorCliente
{
    private RepositorioClientes modelo;
    private VistaCliente vista;
    private bool ejecutado;

    public ControladorCliente(RepositorioClientes modelo, VistaCliente vista)
    {
        this.modelo = modelo;
        this.vista = vista;
        this.ejecutado = true;
    }

    public void StartApp()
    {
        while (ejecutado)
        {
            vista.MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AnadirCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    ejecutado = false;
                    Console.WriteLine("Saliendo de la aplicación...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presiona cualquier tecla para intentarlo de nuevo.");
                    break;
            }
        }
    }

    private void AnadirCliente()
    {
        vista.PedirNombre();
        string nombre = Console.ReadLine();
        vista.PedirTelefono();
        string telefono = Console.ReadLine();
        modelo.AnadirCliente(new Clientes(nombre, telefono));
        Console.WriteLine("\nCliente añadido con éxito!");
    }

    private void ListarClientes()
    {
        List<Clientes> clientes = modelo.ObtenerTodos();
        vista.MostrarListaClientes(clientes);
    }
}
