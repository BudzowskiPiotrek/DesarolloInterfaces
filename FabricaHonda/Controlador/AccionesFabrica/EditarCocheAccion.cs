public class EditarCocheAction
{
    private readonly VistaFabrica vista;
    private readonly RepositorioFabrica modelo;

    public EditarCocheAction(VistaFabrica vista, RepositorioFabrica modelo)
    {
        this.vista = vista;
        this.modelo = modelo;
    }

    public void empezar()
    {
        List<Coche> vechiculos = modelo.ObtenerTodosVehiculos();

        if (!vechiculos.Any())
        {
            vista.mostrarError(8);
            return;
        }
        Console.WriteLine(vista.mensajesControl[4]);
        Console.WriteLine(vista.mensajesControl[17]);
        foreach (Coche c in vechiculos)
        {
            Console.Write($"ID: {c.idVehiculo} , {c.modelo}");
            Console.WriteLine(": " + c.motor.numeroBastidor);
            Console.WriteLine("- " + c.color);
            Console.WriteLine("- " + c.tipoExtra);
        }
        Console.WriteLine(vista.mensajesControl[18]);
        Console.ReadKey(true);

        bool esValido = int.TryParse(Console.ReadLine(), out int numeroId);
        if (!esValido)
        {
            vista.mostrarError(7);
            return;
        }

        Console.WriteLine(vista.mensajesControl[10]);
        string color = Console.ReadLine().ToUpper();
        List<string> coloresPermitidos = modelo.ObtenerColores();
        if (string.IsNullOrWhiteSpace(color) || !coloresPermitidos.Contains(color))
        {
            vista.mostrarError(5);
            return;
        }

        Console.WriteLine(vista.mensajesControl[11]);
        string tipoExtra = Console.ReadLine().ToUpper();
        if (tipoExtra != "STANDARD" && tipoExtra != "SPORT" && tipoExtra != "PRESIDENT")
        {
            vista.mostrarError(4);
            return;
        }

        foreach (Coche c in vechiculos)
        {
            if (c.idVehiculo == numeroId)
            {
                c.color = color;
                c.tipoExtra = tipoExtra;
            }
        }
    }
}