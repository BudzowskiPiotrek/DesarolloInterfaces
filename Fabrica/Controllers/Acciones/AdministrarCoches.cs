
using System.ComponentModel.DataAnnotations;

class AdministrarCoches
{
    private VistaFabrica vista;
    private DbConsultas db;
    private bool ejecutado = true;

    public AdministrarCoches(VistaFabrica vista, DbConsultas db)
    {
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            Console.WriteLine(vista.mensajesControl[7]);
            vista.mostrarMenuCoche();
            ejecutado = menuCoches(Console.ReadLine());
        }
    }

    private bool menuCoches(string opcion)
    {
        switch (opcion)
        {
            case "1":   // LISTAR
                listas();
                return true;
            case "2":   // AÑADIR
                anadir();
                return true;
            case "3":   // EDITAR POR ID LOGICO
                editar();
                return true;
            case "4":   // ASIGNAR MODIFICAR MOTOR
                motor();
                return true;
            case "5":   // CAMBIAR PAQUETE EXTRA
                extra();
                return true;
            case "6":   // CAMBIAR COLOR
                color();
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
        List<Coche> coches = db.ObtenerCoches();

        for (int i = 0; i < coches.Count; i++)
        {
            var c = coches[i];
            Console.WriteLine($"[{i + 1,3}] VIN: {c.VIN,-20}| Modelo: {c.ModeloNombre,-20}| Color: {c.ColorNombre,-20}| Paquete: {c.PaqueteNombre,-20}| Motos Serie: {c.MotorSerie,-20}|");
        }
    }
    public void anadir()
    {
        Console.Write(vista.mensajesControl[19]);
        string vin = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(vin))
        {
            vista.mostrarError(1);
            return;
        }

        Console.Write(vista.mensajesControl[20]);
        if (!int.TryParse(Console.ReadLine(), out int modeloId))
        {
            vista.mostrarError(2);
            return;
        }

        Console.Write(vista.mensajesControl[21]);
        if (!int.TryParse(Console.ReadLine(), out int colorId))
        {
            vista.mostrarError(3);
            return;
        }

        Console.Write(vista.mensajesControl[22]);
        if (!int.TryParse(Console.ReadLine(), out int paqueteId))
        {
            vista.mostrarError(4);
            return;
        }

        Coche nuevoCoche = new Coche(vin, modeloId, colorId, paqueteId);

        try
        {
            db.InsertarCoche(nuevoCoche);
            vista.mostrarConfirmacion(1);
        }
        catch (Exception ex)
        {
            vista.mostrarError(5);
        }
    }
    public void editar()
    {
        List<Coche> coches = db.ObtenerCoches();
        Console.Write(vista.mensajesControl[40]);

        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > coches.Count)
        {
            vista.mostrarError(0);
            return;
        }
        Coche cocheSeleccionado = coches[idLogico - 1];
        Console.WriteLine($"Seleccionado VIN: {cocheSeleccionado.VIN}");


        Console.Write($"Nuevo ModeloId ({cocheSeleccionado.ModeloNombre}): ");
        string idString = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(idString))
        {
            if (int.TryParse(idString, out int idAux))
            {
                cocheSeleccionado.ModeloId = idAux;
            }
            else
            {
                vista.mostrarError(0);
                return;
            }
        }

        Console.Write($"Nuevo ColorId ({cocheSeleccionado.ColorNombre}): ");
        string colorString = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(colorString))
        {
            if (int.TryParse(colorString, out int colorAux))
            {
                cocheSeleccionado.ColorId = colorAux;
            }
            else
            {
                vista.mostrarError(0);
                return;
            }
        }

        Console.Write($"Nuevo PaqueteId ({cocheSeleccionado.PaqueteNombre}): ");
        string extraString = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(extraString))
        {
            if (int.TryParse(extraString, out int extraAux))
            {
                cocheSeleccionado.PaqueteId = extraAux;
            }
            else
            {
                vista.mostrarError(0);
                return;
            }
        }

        try
        {
            db.ActualizarCoche(cocheSeleccionado);
            vista.mostrarConfirmacion(8);
        }
        catch (Exception ex)
        {
            vista.mostrarError(6);
        }

    }
    public void motor()
    {
        List<Coche> coches = db.ObtenerCoches();
        List<Motor> motor = db.ObtenerMotores();
        Console.Write(vista.mensajesControl[24]);
        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > coches.Count)
        {
            vista.mostrarError(0);
            return;
        }
        Coche cocheSeleccionado = coches[idLogico - 1];
        Console.WriteLine($"Seleccionado VIN: {cocheSeleccionado.VIN}, Motor actual: {cocheSeleccionado.MotorSerie ?? "N/A"}");

        var motoresLibres = motor
            .Where(m => !coches.Any(c => c.MotorSerie == m.NumSerie))
            .ToList();

        if (motoresLibres.Count == 0)
        {
            vista.mostrarError(8);
        }
        else
        {
            foreach (var m in motoresLibres)
            {
                Console.WriteLine($"- {m.NumSerie} ( ID: {m.MotorTipoId})");
            }
        }

        Console.Write(vista.mensajesControl[23]);
        string? nuevoMotorSerie = Console.ReadLine()?.Trim();


        if (string.IsNullOrWhiteSpace(nuevoMotorSerie))
        {
            nuevoMotorSerie = null;
        }
        else
        {
            bool existe = motor.Any(m => string.Equals(m.NumSerie, nuevoMotorSerie, StringComparison.OrdinalIgnoreCase));
            if (!existe)
            {
                vista.mostrarError(7);
                return;
            }
        }

        try
        {
            db.AsignarMotorCoche(cocheSeleccionado.VIN, nuevoMotorSerie);
            vista.mostrarConfirmacion(2);
        }
        catch (Exception ex)
        {
            vista.mostrarError(6);
        }
    }
    public void extra()
    {
        List<Coche> coches = db.ObtenerCoches();
        List<PaqueteExtras> paquetes = db.ObtenerPaquetes();

        Console.Write(vista.mensajesControl[25]);
        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > coches.Count)
        {
            vista.mostrarError(0);
            return;
        }

        Coche cocheSeleccionado = coches[idLogico - 1];
        Console.WriteLine($"Seleccionado VIN: {cocheSeleccionado.VIN}, Paquete actual: {cocheSeleccionado.PaqueteNombre ?? "N/A"}");

        foreach (var p in paquetes)
        {
            Console.WriteLine($"[{p.Id}] {p.Nombre}");
        }

        Console.Write(vista.mensajesControl[26]);
        if (!int.TryParse(Console.ReadLine(), out int nuevoPaqueteId) || !paquetes.Any(p => p.Id == nuevoPaqueteId))
        {
            vista.mostrarError(10);
            return;
        }

        try
        {
            db.CambiarPaqueteCoche(cocheSeleccionado.VIN, nuevoPaqueteId);
            vista.mostrarConfirmacion(3);
        }
        catch (Exception ex)
        {
            vista.mostrarError(6);
        }
    }
    public void color()
    {
        List<Coche> coches = db.ObtenerCoches();
        List<Color> colores = db.ObtenerColores();

        Console.Write(vista.mensajesControl[27]);
        if (!int.TryParse(Console.ReadLine(), out int idLogico) || idLogico < 1 || idLogico > coches.Count)
        {
            vista.mostrarError(0);
            return;
        }

        Coche cocheSeleccionado = coches[idLogico - 1];
        Console.WriteLine($"Seleccionado VIN: {cocheSeleccionado.VIN}, Color actual: {cocheSeleccionado.ColorNombre ?? "N/A"}");

        foreach (var c in colores)
        {
            Console.WriteLine($"[{c.Id}] {c.Nombre} ({c.CodigoPintura}, {c.Acabado})");
        }

        Console.Write(vista.mensajesControl[28]);
        if (!int.TryParse(Console.ReadLine(), out int nuevoColorId) || !colores.Any(c => c.Id == nuevoColorId))
        {
            vista.mostrarError(11);
            return;
        }

        try
        {
            db.CambiarColorCoche(cocheSeleccionado.VIN, nuevoColorId);
            vista.mostrarConfirmacion(4);
        }
        catch (Exception ex)
        {
            vista.mostrarError(6);
        }
    }
}