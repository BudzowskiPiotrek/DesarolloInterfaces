using System;


/// <summary>
/// Clase Vista_Examen - punto de partida para implementar la vista del examen.
/// </summary>
public class Vista_Examen
{
    public readonly List<string> mensajesControl = new List<string>
    {
        "╔════════════════════════════════════════════════╗",        // [0] 
        "║         MENÚ RESTAURANTE         ",                       // [1] 
        "╠════════════════════════════════════════════════╣",        // [2] 
        "║ 👉 1️⃣  MENU PRINCIPAL         ",                         // [3] 
        "║ 👉 0️⃣  Salir                  ",                         // [4] 
        "╚════════════════════════════════════════════════╝",        // [5] 
        "          Elige una opción:",                               // [6] 
        "╔════════════════════════════════════════════════╗",        // [7] 
        "║         MENÚ RESTAURANTE         ",                       // [8] 
        "╠════════════════════════════════════════════════╣",        // [9] 
        "║ 👉 1️⃣  ELEGIR MESA         ",                            // [10] 
        "║ 👉 0️⃣  Volver                  ",                        // [11] 
        "╚════════════════════════════════════════════════╝",        // [12] 
        "          Elige una opción:",                               // [13] 
        "╔════════════════════════════════════════════════╗",        // [14] 
        "║         MENÚ RESTAURANTE         ",                       // [15] 
        "╠════════════════════════════════════════════════╣",        // [16] 
        "║ 👉 1️⃣  LISTAR PEDIDOS         ",                         // [17] 
        "║ 👉 3️⃣  AÑADIR PEDIDOS        ",                          // [18] 
        "║ 👉 0️⃣  Volver                  ",                        // [19] 
        "╚════════════════════════════════════════════════╝",        // [20] 
        "          Elige una opción:",                               // [21] 
        "Listado de categorias Disponibles:",                        // [22]
        "0: Volver:",                                                // [23]
        "-----------------------------\n",                         // [24]
        "Cual es numero de la mesa que vas a elegir?\n",           // [25]
        "\n--- LISTADO DE MESAS ---",                              // [26]
        "No se encontraron registros.",                            // [27]
        "\n--- Presentaciones disponibles ---",                    // [28]
        
        
    };
    private readonly List<string> mensajesConfirmacion = new List<string>
    {
        "✅ Saliendo de la aplicación. ",                              // [0]      
        "✅ Registro insertado correctamente. ",                       // [1]   
    };

    private readonly List<string> mensajesError = new List<string>
    {
        "❌ Opción no válida. Vuelve a intentar.",           // [0]

    };
    public void espera()
    {
        Console.WriteLine("-----------------------------\n");
        Console.WriteLine("Presiona cualquier tecla para continuar...\n");
        Console.ReadKey(true);
    }

    public void mostrarMenu()
    {
        Console.Clear();
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(mensajesControl[i]);
        }
    }
    public void mostrarMenuPrincipal()
    {
        //Console.Clear();
        for (int i = 7; i < 14; i++)
        {
            Console.WriteLine(mensajesControl[i]);
        }
    }
    public void mostrarMenuMesa()
    {
        //Console.Clear();
        for (int i = 14; i < 22; i++)
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
            Console.WriteLine("\nAnda presiona cualquier tecla para continuar...");
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
            Console.WriteLine("\nAnda presiona cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }

}


