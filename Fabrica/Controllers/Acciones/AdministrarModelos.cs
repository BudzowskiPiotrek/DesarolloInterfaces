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
            // IMPRIMIR MENU
            ejecutado = menuModelos(Console.ReadLine());
        }
    }

    private bool menuModelos(string opcion)
    {
        switch (opcion)
        {
            case "1":   // LISTAR
                
                return true;
            case "2":   // AÑADIR TEST
                ModeloHonda nuevoModelo = new ModeloHonda("V-TURBO");
                db.InsertarModelo(nuevoModelo);
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