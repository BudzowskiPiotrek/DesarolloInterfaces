public class ControladorCliente
{
    private ContenedorClientes modelo;
    private VistaCliente vista;
    private bool estaCorriendo;

    public ControladorCliente(ContenedorClientes modelo, VistaCliente vista)
    {
        this.modelo = modelo;
        this.vista = vista;
        this.estaCorriendo = true;
    }

    public void StartApp()
    {
        while (estaCorriendo)
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
                    estaCorriendo = false;
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
