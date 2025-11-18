class AdministrarModelos
{
    private VistaFabrica vista;
    private DbConsultas db;
    private bool ejecutado = true;

    public AdministrarModelos(VistaFabrica vista, DbConsultas db)
    {
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            Console.WriteLine(vista.mensajesControl[8]);
            vista.mostrarMenuComun();
            ejecutado = menuModelos(Console.ReadLine());
        }
    }

    private bool menuModelos(string opcion)
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
        List<ModeloHonda> modelos = db.ObtenerModelos();
        for (int i = 0; i < modelos.Count; i++)
        {
            var m = modelos[i];
            Console.WriteLine($"[{i + 1,3}] Nombre: {m.Nombre,-20} | Código: {m.CodigoModelo ?? "N/A",-10} | Segmento: {m.Segmento ?? "N/A",-10}");
        }

    }
    public void anadir()
    {
        Console.Write(vista.mensajesControl[29]);
        string nombre = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            vista.mostrarError(0);
            return;
        }

        Console.Write(vista.mensajesControl[30]);
        string? codigo = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(codigo)) codigo = null;

        Console.Write(vista.mensajesControl[31]);
        string? segmento = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(segmento)) segmento = null;

        ModeloHonda nuevoModelo = new ModeloHonda
        {
            Nombre = nombre,
            CodigoModelo = codigo,
            Segmento = segmento
        };

        try
        {
            db.InsertarModelo(nuevoModelo);
            vista.mostrarConfirmacion(5);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            vista.mostrarError(5);
            
        }
    }
    public void editar()
    {
        List<ModeloHonda> modelos = db.ObtenerModelos();

        Console.Write(vista.mensajesControl[32]);
        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > modelos.Count)
        {
            vista.mostrarError(0); 
            return;
        }

        ModeloHonda modeloSeleccionado = modelos[idLogico - 1];

        Console.Write($"Nuevo nombre ({modeloSeleccionado.Nombre}): ");
        string? nombre = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(nombre)) modeloSeleccionado.Nombre = nombre;

        Console.Write($"Nuevo código ({modeloSeleccionado.CodigoModelo ?? "N/A"}): ");
        string? codigo = Console.ReadLine()?.Trim();
        modeloSeleccionado.CodigoModelo = string.IsNullOrWhiteSpace(codigo) ? modeloSeleccionado.CodigoModelo : codigo;

        Console.Write($"Nuevo segmento ({modeloSeleccionado.Segmento ?? "N/A"}): ");
        string? segmento = Console.ReadLine()?.Trim();
        modeloSeleccionado.Segmento = string.IsNullOrWhiteSpace(segmento) ? modeloSeleccionado.Segmento : segmento;

        try
        {
            db.ActualizarModelo(modeloSeleccionado);
            vista.mostrarConfirmacion(6); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            vista.mostrarError(6);
            
        }
    }
}