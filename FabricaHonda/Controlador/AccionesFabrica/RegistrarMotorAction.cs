public class RegistrarMotorAction
{
    private readonly VistaFabrica vista;
    private readonly RepositorioFabrica modelo;

    public RegistrarMotorAction(VistaFabrica vista, RepositorioFabrica modelo)
    {
        this.vista = vista;
        this.modelo = modelo;
    }

    public void empezar()
    {
        Console.WriteLine(vista.mensajesControl[1]);
        Console.WriteLine(vista.mensajesControl[8]);

        if (!int.TryParse(Console.ReadLine(), out int bastidor))
        {
            vista.mostrarError(3);
            return;
        }


        Console.WriteLine(vista.mensajesControl[12]);
        string tipoMotor = Console.ReadLine().ToUpper();

        if (string.IsNullOrWhiteSpace(tipoMotor) || (tipoMotor != "HIBRIDO" && tipoMotor != "DIESEL" && tipoMotor != "GASOLINA"))
        {
            vista.mostrarError(4);
            return;
        }


        Console.WriteLine(vista.mensajesControl[13]);
        string cilindrada = Console.ReadLine().ToUpper();

        if (string.IsNullOrWhiteSpace(cilindrada) || (cilindrada != "1.5" && cilindrada != "1.9" && cilindrada != "2.0" && cilindrada != "2.1" && cilindrada != "3.0"))
        {
            vista.mostrarError(0);
            return;
        }
        string tipoMotorCompleto = $"{tipoMotor} {cilindrada}".ToLower();

        try
        {
            Motor nuevoMotor = new Motor(bastidor, tipoMotorCompleto, cilindrada);

            modelo.RegistrarMotor(nuevoMotor);

            vista.mostrarConfirmacion(1);
        }
        catch (Exception)
        {
            vista.mostrarError(0);
        }
    }
}
