public class Controlador
{
    private DB_Consultas db;
    private Vista_Examen vista;
    private bool ejecutado = true;

    public Controlador()
    {
        this.db = new DB_Consultas();
        this.vista = new Vista_Examen();
    }
    public void startApp()
    {
        while (ejecutado)
        {
            vista.mostrarMenu();
            ejecutado = menuSwitch(Console.ReadLine() ?? "");
        }
    }
    private bool menuSwitch(string opcion)
    {
        switch (opcion.Trim().ToLower())
        {
            case "1":
                new ControladorOpcionUno(vista, db).Empezar();
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