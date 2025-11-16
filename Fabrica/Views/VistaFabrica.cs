
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
        "** FÁBRICA HONDA: MENÚ COCHE **",     // [7] 
        "** FÁBRICA HONDA: MENÚ MODELO **",    // [8] 
        "** FÁBRICA HONDA: MENÚ EXTRAS **",    // [9] 
        "** FÁBRICA HONDA: MENÚ COLOR **",     // [10] 
        "1. Listar",                           // [11]
        "2. Añadir",                           // [12]
        "3. Editar por id_lógico",             // [13]
        "0. Volver",                           // [14]
        "3. Editar coche por id_lógico",       // [15]
        "4. Asignar/Modificar Motor",          // [16]
        "5. Cambiar Paquete (Extras)",         // [17]
        "6. Cambiar Color",                    // [18]
        "Introduce VIN: (17 Caracteres 0-9 y A-Z) ",                              // [19]
        "Introduce ID de modelo: ",            // [20]
        "Introduce ID de color: ",             // [21]
        "Introduce ID de paquete: ",           // [22]
        "Introduce uno de los modelos disponibles (deja vacío para eliminar): ",  // [23]
        "Introduce el ID lógico del coche para asignar o cambiar motor: ",        // [24]
        "Introduce el ID lógico del coche para cambiar el paquete: ",             // [25]
        "Introduce el ID del paquete que quieres asignar: ",                      // [26]
        "Introduce el ID lógico del coche para cambiar el color: ",               // [27]
        "Introduce el ID del color que quieres asignar: ",                        // [28]
        "Introduce el nombre del modelo: ",                                       // [29]
        "Introduce el código del modelo (opcional - si no quieres pulsa enter): ",// [30]
        "Introduce el segmento (opcional - si no quieres pulsa enter): ",         // [31]
        "Introduce el ID lógico del modelo a editar: ",                           // [32]
        "Introduce el ID lógico del color a editar: ",                            // [33]
        "Introduce el nombre del color:",                                         // [34]
        "Introduce el código de pintura: ",                                       // [35]
        "Introduce el acabado: ",                                                 // [36]
        "Introduce el nombre del paquete extra:",                                 // [37]
        "Introduce la descripción (opcional):",                                   // [38]
        "Introduce el ID lógico del paquete a editar:",                           // [39]
        "Introduce el ID lógico del coche",                                       // [40]
        "",                    // [41]
    };

    private readonly List<string> mensajesError = new List<string>
    {
        "❌ Opción no válida. Vuelve a intentar.",           // [0]
        "❌ El VIN no puede estar vacío o tener menos de 17 Caracteres.",                   // [1]
        "❌ ID de modelo no válido.",                        // [2]
        "❌ ID de color no válido.",                         // [3]
        "❌ ID de paquete no válido.",                       // [4]
        "❌ Error al insertar",                              // [5]
        "❌ Error al actualizar.",                           // [6]
        "❌ El número de serie no existe.",                  // [7]
        "❌ No hay motores disponibles actualmente.",        // [8]
        "❌ Error al actualizar el motor.",                  // [9]
        "❌ Paquete inválido",                               // [10]
        "❌ Color inválido.",                                // [11]
        "❌",                  // [12]
    };

    private readonly List<string> mensajesConfirmacion = new List<string>
    {
        "✅ Saliendo de la aplicación. ",                              // [0] 
        "✅ Coche añadido correctamente.",                             // [1]
        "✅ Motor actualizado correctamente.",                         // [2]
        "✅ Paquete actualizado correctamente",                        // [3]
        "✅ Color actualizado correctamente.",                         // [4]
        "✅ Modelo agregado correctamente",                            // [5]
        "✅ Modelo actualizado correctamente",                         // [6]
        "✅ Color agregado correctamente",                             // [7]
        "✅ Color actualizado correctamente",                          // [8]
        "✅ Paquete agregado correctamente",                           // [9]
        "✅ Paquete actualizado correctamente",                        // [10]
        "✅ ",                          // [11]
    };
    public void mostrarMenuPrincipal()
    {
        Console.Clear();
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(mensajesControl[i]);
        }
    }
    public void mostrarMenuComun()
    {
        for (int i = 11; i < 15; i++)
        {
            Console.WriteLine(mensajesControl[i]);
        }
        Console.WriteLine(mensajesControl[6]);
    }
    public void mostrarMenuCoche()
    {
        for (int i = 11; i < 19; i++)
        {
            if (i == 13 || i == 14)
            {
                continue;
            }
            Console.WriteLine(mensajesControl[i]);
        }
        Console.WriteLine(mensajesControl[14]);
        Console.WriteLine(mensajesControl[6]);
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