using System.Collections.Generic;
using System;
using System.Linq;

public class ControladorOpcionUno
{
    private Vista_Examen vista;
    private DB_Consultas db;
    private bool ejecutado = true;

    public ControladorOpcionUno(Vista_Examen vista, DB_Consultas db)
    {
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            vista.mostrarMenuPrincipal();
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
            case "0":   // SALIR
                return false;
            default:
                vista.mostrarError(0);
                return true;
        }
    }

    private void MetodoListar()
    {
        Console.WriteLine(vista.mensajesControl[26]);
        var registros = db.LeerDatos("mesas").ToList();

        int numeroLogico = 1;

        foreach (var registro in registros)
        {
            foreach (var kvp in registro)
                Console.Write($"{numeroLogico,-15}{kvp.Key}: {kvp.Value,-15} | ");
            Console.WriteLine();
            numeroLogico++;
        }
        Console.WriteLine(vista.mensajesControl[24]);
        Console.WriteLine(vista.mensajesControl[25]);

        try
        {
            int seleccion = Convert.ToInt32(Console.ReadLine());

            if (seleccion < 1 || seleccion > registros.Count)
            {
                vista.mostrarError(0);
                return;
            }

            var registroSeleccionado = registros[seleccion - 1];
            int idReal = Convert.ToInt32(registroSeleccionado["id"]);
            vista.espera();
            new ControladorOpcionDos(vista, db, idReal).Empezar();
        }
        catch
        {
            vista.mostrarError(0);
        }
    }
}