
class ControladorFabrica
{
    private DbConsultas db;
    private VistaFabrica vista;

    private bool ejecutado = true;

    public ControladorFabrica()
    {
        db = new DbConsultas();
        vista = new VistaFabrica();
    }

    public void StartApp()
    {
        while (ejecutado)
        {
            vista.mostrarMenuPrincipal();
            ejecutado = menuSwitch(Console.ReadLine());
        }
    }

    private bool menuSwitch(string opcion)
    {
        switch (opcion)
        {
            case "1":
                var adminCoches = new AdministrarCoches(vista, db);
                adminCoches.Empezar();
                return true;
            case "2":
                var adminModelos = new AdministrarModelos(vista, db);
                adminModelos.Empezar();
                return true;
            case "3":
                var adminExtras = new AdministrarExtras(vista, db);
                adminExtras.Empezar();
                return true;
            case "4":
                var adminColores = new AdministrarColores(vista, db);
                adminColores.Empezar();
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
