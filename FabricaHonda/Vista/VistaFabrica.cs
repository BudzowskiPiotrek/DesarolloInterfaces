public class VistaFabrica
{
    public void mostrarMenu()
    {
        Console.Clear();
        for (int i = 0; i < 8; i++)
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
    
    private readonly List<string> mensajesControl = new List<string>
    {
        "** FÁBRICA HONDA: MENÚ PRINCIPAL **", // [0] 
        "1. Registrar nuevo motor",            // [1]
        "2. Seguimiento de motor por bastidor",// [2]
        "3. Construir vehículo nuevo",         // [3]
        "4. Editar vehículo existente",        // [4]
        "5. Editar lista de colores",          // [5]
        "0. Salir de la aplicación",           // [6]
        "** ¿Elige una opcion? **"             // [7]
    };

    private readonly List<string> mensajesError = new List<string>
    {
        "❌ Opción no válida. Por favor, introduce un número del menú. ❌",              // [0] 
        "❌ El motor no fue encontrado o ya está montado en un vehículo. ❌",            // [1] 
        "❌ Restricción: La Gasolina 3.0 solo se puede montar en el modelo 'Civic'. ❌", // [2] 
        "❌ El bastidor introducido debe ser numérico. ❌"                               // [3] 
    };

    private readonly List<string> mensajesConfirmacion = new List<string>
    {
        "✅ Saliendo de la aplicación.✅",                        // [0] 
        "✅ Motor registrado correctamente en el inventario. ✅", // [1]
        "✅ Vehículo construido ✅"                               // [2] 
    };
}