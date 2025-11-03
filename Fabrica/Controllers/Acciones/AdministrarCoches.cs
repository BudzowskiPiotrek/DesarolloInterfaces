
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
        foreach (var c in coches)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"VIN    : {c.VIN}");
            Console.WriteLine($"Modelo : {c.ModeloNombre}");
            Console.WriteLine($"Color  : {c.ColorNombre}");
            Console.WriteLine($"Paquete: {c.PaqueteNombre}");
        }
    }
    public void anadir()
    {
        Coche nuevoCoche = new Coche(
                    vin: "CRISTOBAL-MOBILE",
                    modeloId: 1,
                    colorId: 5,
                    paqueteId: 2
                );
                db.InsertarCoche(nuevoCoche);
    }
    public void editar() { }
    public void motor() { }
    public void extra() { }
    public void color() { }
}