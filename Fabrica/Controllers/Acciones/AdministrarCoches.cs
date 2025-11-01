
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
            // IMPRIMIR MENU
            ejecutado = menuCoches(Console.ReadLine());
        }
    }

    private bool menuCoches(string opcion)
    {
        switch (opcion)
        {
            case "1":   // LISTAR
                List<Coche> coches = db.ObtenerCoches();
                foreach (var c in coches)
                {   
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"VIN    : {c.VIN}");
                    Console.WriteLine($"Modelo : {c.ModeloNombre}");
                    Console.WriteLine($"Color  : {c.ColorNombre}");
                    Console.WriteLine($"Paquete: {c.PaqueteNombre}");
                }
                return true;
            case "2":   // AÑADIR TEST
                Coche nuevoCoche = new Coche(
                    vin: "CRISTOBAL-MOBILE",
                    modeloId: 1,
                    colorId: 5,
                    paqueteId: 2
                );
                db.InsertarCoche(nuevoCoche);
                return true;
            case "3":   // EDITAR
                
                return true;
            case "0":   // SALIR
                return false;
            default:
                vista.mostrarError(0);
                return true;
        }
    }  
}