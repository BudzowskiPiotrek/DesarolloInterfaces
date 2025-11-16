
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
    public void listas()
    {
        List<Color> colores = db.ObtenerColores();

        for (int i = 0; i < colores.Count; i++)
        {
            var c = colores[i];
            Console.WriteLine($"[{i + 1,3}] Nombre: {c.Nombre,-20} | Código Pintura: {c.CodigoPintura,-10} | Acabado: {c.Acabado,-10}");
        }
    }
    public void anadir()
    {
        Console.Write(vista.mensajesControl[34]);
        string nombre = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            vista.mostrarError(0);
            return;
        }

        Console.Write(vista.mensajesControl[35]);
        string codigo = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(codigo))
        {
            vista.mostrarError(0);
            return;
        }

        Console.Write(vista.mensajesControl[36]);
        string acabado = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(acabado))
        {
            vista.mostrarError(0);
            return;
        }

        Color nuevoColor = new Color
        {
            Nombre = nombre,
            CodigoPintura = codigo,
            Acabado = acabado
        };

        try
        {
            db.InsertarColor(nuevoColor);
            vista.mostrarConfirmacion(7);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            vista.mostrarError(5);
        }
    }
    public void editar()
    {
        List<Color> colores = db.ObtenerColores();

        Console.Write(vista.mensajesControl[33]);
        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > colores.Count)
        {
            vista.mostrarError(0);
            return;
        }

        Color colorSeleccionado = colores[idLogico - 1];

        Console.Write($"Nuevo nombre ({colorSeleccionado.Nombre}): ");
        string? nombre = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(nombre)) colorSeleccionado.Nombre = nombre;

        Console.Write($"Nuevo código de pintura ({colorSeleccionado.CodigoPintura}): ");
        string? codigo = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(codigo)) colorSeleccionado.CodigoPintura = codigo;

        Console.Write($"Nuevo acabado ({colorSeleccionado.Acabado}): ");
        string? acabado = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(acabado)) colorSeleccionado.Acabado = acabado;

        try
        {
            db.ActualizarColor(colorSeleccionado);
            vista.mostrarConfirmacion(8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            vista.mostrarError(6);
        }
    }
}