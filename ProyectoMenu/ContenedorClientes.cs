public class ContenedorClientes
{
    private List<Clientes> clientes = new List<Clientes>();

    public void AnadirCliente(Clientes cliente)
    {
        clientes.Add(cliente);
    }

    public List<Clientes> ObtenerTodos()
    {
        return clientes;
    }
}