
class AdministrarExtras
{
    private VistaFabrica vista;
    private DbConsultas db;
    private bool ejecutado = true;

    public AdministrarExtras(VistaFabrica vista, DbConsultas db)
    {
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            Console.WriteLine(vista.mensajesControl[9]);
            vista.mostrarMenuComun();
            ejecutado = menuExtras(Console.ReadLine());
        }
    }

    private bool menuExtras(string opcion)
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
    public void listas()
    {
        List<PaqueteExtras> paquetes = db.ObtenerPaquetes();

        for (int i = 0; i < paquetes.Count; i++)
        {
            var p = paquetes[i];
            Console.WriteLine($"[{i + 1,3}] Nombre: {p.Nombre,-20} | Descripción: {p.Descripcion ?? "N/A",-30}");
        }
    }
    public void anadir()
    {
        List<PaqueteExtras> paquetes = db.ObtenerPaquetes();

        Console.Write(vista.mensajesControl[37]);
        string nombre = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(nombre))
        {
            vista.mostrarError(0);
            return;
        }

        Console.Write(vista.mensajesControl[38]);
        string? descripcion = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(descripcion)) descripcion = null;

        PaqueteExtras nuevoPaquete = new PaqueteExtras
        {
            Nombre = nombre,
            Descripcion = descripcion
        };

        try
        {
            db.InsertarPaquete(nuevoPaquete);
            vista.mostrarConfirmacion(9);
        }
        catch (Exception ex)
        {
            vista.mostrarError(5);
        }
    }
    public void editar()
    {
        List<PaqueteExtras> paquetes = db.ObtenerPaquetes();
        
        Console.Write(vista.mensajesControl[39]);
        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > paquetes.Count)
        {
            vista.mostrarError(0);
            return;
        }

        PaqueteExtras paqueteSeleccionado = paquetes[idLogico - 1];

        Console.Write($"Nuevo nombre ({paqueteSeleccionado.Nombre}): ");
        string? nombre = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(nombre)) paqueteSeleccionado.Nombre = nombre;

        Console.Write($"Nueva descripción ({paqueteSeleccionado.Descripcion ?? "N/A"}): ");
        string? descripcion = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(descripcion)) paqueteSeleccionado.Descripcion = descripcion;

        try
        {
            db.ActualizarPaquete(paqueteSeleccionado);
            vista.mostrarConfirmacion(10); 
        }
        catch (Exception ex)
        {
            vista.mostrarError(6);
        }
    }
}