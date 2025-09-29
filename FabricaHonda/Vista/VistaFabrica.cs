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

    public readonly List<string> mensajesControl = new List<string>
    {
        "** FÁBRICA HONDA: MENÚ PRINCIPAL **",  // [0] 
        "1. Registrar nuevo motor",             // [1]
        "2. Seguimiento de motor por bastidor", // [2]
        "3. Construir vehículo nuevo",          // [3]
        "4. Editar vehículo existente",         // [4]
        "5. Editar lista de colores",           // [5]
        "0. Salir de la aplicación",            // [6]
        "** ¿Elige una opcion? **",             // [7]
        "Introduce el número de bastidor del motor a montar:",         // [8] 
        "Introduce el MODELO del vehículo (CIVIC, H-RV, Z-RV, C-RV):", // [9]
        "Introduce el COLOR del vehículo:",                            // [10]
        "Introduce el TIPO EXTRA (STANDARD, SPORT, PRESIDENT):",       // [11] 
        "Introduce el TIPO DE MOTOR (HIBRIDO, DIESEL, GASOLINA):",     // [12]
        "Introduce la CILINDRADA (1.5, 1.9, 2.0, 2.1, 3.0 ):"          // [13]
    };

    private readonly List<string> mensajesError = new List<string>
    {
        "❌ Opción no válida. Por favor, introduce un número del menú. ❌",              // [0] 
        "❌ El motor no fue encontrado o ya está montado en un vehículo. ❌",            // [1] 
        "❌ Restricción: La Gasolina 3.0 solo se puede montar en el modelo 'Civic'. ❌", // [2] 
        "❌ El bastidor introducido debe ser numérico. ❌",                              // [3] 
        "❌ El motor no fue encontrado ❌"                                               // [4]  
        
    };

    private readonly List<string> mensajesConfirmacion = new List<string>
    {
        "✅ Saliendo de la aplicación.✅",                            // [0] 
        "✅ Motor registrado correctamente en el inventario. ✅",     // [1]
        "✅ Vehículo construido ✅",                                  // [2] 
        "✅ RESULTADO: Motor con bastidor está MONTADO ✅",           // [3]
        "📦 RESULTADO: Motor con bastidor está DISPONIBLE en almacén."// [4]
    };
}