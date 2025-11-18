class Program
{
    static void Main(string[] args)
    {
        var modelo = new RepositorioClientes();
        var vista = new VistaCliente();
        var controlador = new ControladorCliente(modelo, vista);
        
        controlador.StartApp();
    }
}
