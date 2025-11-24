using System.Collections.Generic;
using System.Collections.Generic;

public class ControladorOpcionTres
{
    private Vista_Examen vista;
    private DB_Consultas db;
    private int numeroLogico;
    private bool ejecutado = true;

    public ControladorOpcionTres(Vista_Examen vista, DB_Consultas db, int numeroLogico)
    {
        this.numeroLogico = numeroLogico;
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            MostrarCategorias();
        }
    }

    private void MostrarCategorias()
    {
        Console.WriteLine($"\n--- PEDIDO DE LA MESA {numeroLogico}, Seleccion de Catgoria---");
        var registros = db.LeerDatos("categorias");

        int idLogicoCategoria = 1;

        foreach (var registro in registros)
        {
            foreach (var kvp in registro)
                Console.Write($"{idLogicoCategoria}: {kvp.Value,-15} | ");
            Console.WriteLine();
            idLogicoCategoria++;
        }

        Console.WriteLine(vista.mensajesControl[23]);
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());
        if (idSeleccionado == 0)
        {
            ejecutado = false;
            return;
        }

        var registroSeleccionado = registros.ElementAt(idSeleccionado - 1);
        int idSQL = Convert.ToInt32(registroSeleccionado["id"]);
        vista.espera();
        new ControladorOpcionCuatro(vista, db, numeroLogico, idSQL).Empezar();
    }
}