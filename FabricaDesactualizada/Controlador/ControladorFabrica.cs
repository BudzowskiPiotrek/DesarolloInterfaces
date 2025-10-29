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
            vista.mostrarMenu();
            string opcion = Console.ReadLine();
            ejecutado = DespacharAccion(opcion);
        }
    }
    private bool DespacharAccion(string opcion)
    {
        switch (opcion)
        {
            case "1":
                RegistrarMotorAction registrar = new RegistrarMotorAction(vista, modelo);
                registrar.empezar();
                return true;
            case "2":
                SeguimientoAction seguimiento = new SeguimientoAction(vista, modelo);
                seguimiento.empezar();
                return true;
            case "3":
                ConstruirCocheAction construir = new ConstruirCocheAction(vista, modelo);
                construir.empezar();
                return true;
            case "4":
                EditarCocheAction editarCoche = new EditarCocheAction(vista, modelo);
                editarCoche.empezar();
                return true;
            case "5":
                EditarColoresAction editarColores = new EditarColoresAction(vista, modelo);
                editarColores.empezar();
                return true;
            case "0":
                vista.mostrarConfirmacion(0);
                return false;
            default:
                vista.mostrarError(0);
                return true;
        }
    }
}