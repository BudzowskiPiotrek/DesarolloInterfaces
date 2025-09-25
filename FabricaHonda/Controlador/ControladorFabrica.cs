public class ControladorFabrica
{
    private VistaFabrica vista;
    private RepositorioFabrica modelo;
    private bool ejecutado = true;

    public ControladorFabrica()
    {
        this.vista = new VistaFabrica();
        this.modelo = new RepositorioFabrica();
    }
    public void StartApp()
    {
        while (ejecutado)
        {
            vista.MostrarMenu();

        }
    }
}