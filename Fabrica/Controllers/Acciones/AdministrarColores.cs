
class AdministrarColores
{
    private VistaFabrica vista;
    private DbConsultas db;
    private bool ejecutado = true;

    public AdministrarColores(VistaFabrica vista, DbConsultas db)
    {
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            Console.WriteLine(vista.mensajesControl[10]);
            vista.mostrarMenuComun();
            ejecutado = menuColores(Console.ReadLine());
        }
    }

    private bool menuColores(string opcion)
    {
        switch (opcion)
        {
            case "1":   // LISTAR
                listas();
                return true;
            case "2":   // AÑADIR
                anadir();
                return true;
            case "3":   // EDITAR
                editar();
                return true;
            case "0":   // SALIR
                return false;
            default:
                vista.mostrarError(0);
                return true;
        }
    }
    public void listas() { }
    public void anadir() { }
    public void editar() { }
}