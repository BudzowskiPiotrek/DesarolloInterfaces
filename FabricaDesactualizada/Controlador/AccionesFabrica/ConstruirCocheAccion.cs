public class ConstruirCocheAction
{
    private readonly VistaFabrica vista;
    private readonly RepositorioFabrica modelo;

    public ConstruirCocheAction(VistaFabrica vista, RepositorioFabrica modelo)
    {
        this.vista = vista;
        this.modelo = modelo;
    }

    public void empezar()
    {
        Console.WriteLine(vista.mensajesControl[3]);
        Console.WriteLine(vista.mensajesControl[8]);

        bool esValido = int.TryParse(Console.ReadLine(), out int bastidorMotor);
        if (!esValido)
        {
            vista.mostrarError(3);
            return;
        }

        Motor motorSeleccionado = null;
        foreach (Motor motor in modelo.ObtenerMotoresDisponibles())
        {
            if (motor.numeroBastidor == bastidorMotor && motor.montado == false)
            {
                motorSeleccionado = motor;
                break;
            }
        }
        if (motorSeleccionado == null)
        {
            vista.mostrarError(1);
            return;
        }


        Console.WriteLine(vista.mensajesControl[9]);
        string modeloCoche = Console.ReadLine().ToUpper();
        if (modeloCoche != "CIVIC" && modeloCoche != "H-RV" && modeloCoche != "Z-RV" && modeloCoche != "C-RV")
        {
            vista.mostrarError(4);
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

        if (motorSeleccionado.tipoMotor == "GASOLINA 3.0" && modeloCoche != "CIVIC")
        {
            vista.mostrarError(2);
            return;
        }

        try
        {
            modelo.ConstruirVehiculo(modeloCoche, color, tipoExtra, bastidorMotor);

            vista.mostrarConfirmacion(2);
        }
        catch (Exception)
        {
            vista.mostrarError(4);
        }
    }
}
