public class EditarColoresAction
{
    private readonly VistaFabrica vista;
    private readonly RepositorioFabrica modelo;

    public EditarColoresAction(VistaFabrica vista, RepositorioFabrica modelo)
    {
        this.vista = vista;
        this.modelo = modelo;
    }
    public void empezar()
    {
        Console.WriteLine(vista.mensajesControl[5]);

        List<string> coloresActuales = modelo.ObtenerColores();

        Console.WriteLine(vista.mensajesControl[14]);

        foreach (string color in coloresActuales)
        {
            Console.WriteLine($"  - {color}");
        }

        Console.WriteLine(vista.mensajesControl[15]);
        string colorEntrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(colorEntrada))
        {
            vista.mostrarError(0);
            return;
        }

        string nuevoColorUpper = colorEntrada.ToUpper();
        if (coloresActuales.Contains(nuevoColorUpper))
        {
            vista.mostrarError(6);
            return;
        }

        try
        {
            modelo.AgregarColor(nuevoColorUpper);
            vista.mostrarConfirmacion(5);
        }
        catch (Exception)
        {
            vista.mostrarError(0);
        }
    }
}