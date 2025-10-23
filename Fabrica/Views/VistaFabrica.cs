
class VistaFabrica
{
    public readonly List<string> mensajesControl = new List<string>
    {
        "** FÁBRICA HONDA: MENÚ PRINCIPAL **", // [0] 
        "1. Administrar Coches",               // [1]
        "2. Administrar Modelos",              // [2]
        "3. Administrar Extras (Paquetes)",    // [3]
        "4. Administrar Colores",              // [4]
        "0. Salir",                            // [5]
        "** ¿Elige una opcion? **",            // [6]
        ""                                     // [7]
    };

    private readonly List<string> mensajesError = new List<string>
    {
        "❌ Opción no válida. Vuelves al menu principal  . ❌",        // [0] 
    };

    private readonly List<string> mensajesConfirmacion = new List<string>
    {
        "✅ Saliendo de la aplicación.✅",                             // [0] 
    };

    public void mostrarMenu()
    {
        Console.Clear();
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(mensajesControl[i]);
        }
    }
    public void mostrarConfirmacion(int numero)
    {
        if (numero >= 0 && numero < mensajesConfirmacion.Count)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{mensajesConfirmacion[numero]}");
            Console.ResetColor();
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }
    public void mostrarError(int numero)
    {
        if (numero >= 0 && numero < mensajesError.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{mensajesError[numero]}");
            Console.ResetColor();
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}