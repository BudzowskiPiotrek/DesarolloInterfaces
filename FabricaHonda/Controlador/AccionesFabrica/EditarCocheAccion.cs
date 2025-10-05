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

        foreach (Coche c in vechiculos)
        {
            Console.WriteLine(c.idVehiculo);
            Console.WriteLine(c.modelo);
            Console.WriteLine(c.motor.numeroBastidor);
            Console.WriteLine(c.color);
            Console.WriteLine(c.tipoExtra);

        }
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey(true);
    }
}