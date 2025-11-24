using System.Collections.Generic;
public class ControladorOpcionDos
{
    private Vista_Examen vista;
    private DB_Consultas db;
    private int numeroLogico;
    private bool ejecutado = true;

    public ControladorOpcionDos(Vista_Examen vista, DB_Consultas db, int numeroLogico)
    {
        this.vista = vista;
        this.numeroLogico = numeroLogico;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            vista.mostrarMenuMesa();
            ejecutado = menu(Console.ReadLine());
        }
    }
    private bool menu(string opcion)
    {
        switch (opcion)
        {
            case "1":   // LISTAR
                MetodoListar();
                return true;
            case "2":   // ANADIR
                new ControladorOpcionTres(vista, db, numeroLogico).Empezar();
                return true;
            case "0":   // SALIR
                return false;
            default:
                vista.mostrarError(0);
                return true;
        }
    }
private void MetodoListar()
    {
        Console.WriteLine($"\n--- PEDIDOS DE LA MESA  {numeroLogico}---");
        var registros = db.LeerDatosCon("pedidos", $"id_mesa = {numeroLogico}");

        int contador = 1;

        if (registros.Count == 0)
        {
            Console.WriteLine(vista.mensajesControl[27]);
            return;
        }

        foreach (var registro in registros)
        {

            foreach (var kvp in registro)
                Console.Write($"{contador,-20}{kvp.Key}: {kvp.Value,-15} | ");
            Console.WriteLine();
            contador++;
        }
        Console.WriteLine(vista.mensajesControl[24]);
    }
    
}