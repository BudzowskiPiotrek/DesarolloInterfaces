using System.Collections.Generic;
public class ControladorOpcionCuatro
{
    private Vista_Examen vista;
    private DB_Consultas db;
    private int idMesa;
    private int idCategoria;
    private bool ejecutado = true;

    public ControladorOpcionCuatro(Vista_Examen vista, DB_Consultas db, int numeroLogico, int idSQL)
    {
        this.idMesa = numeroLogico;
        this.idCategoria = idSQL;
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            MostrarProductos();

        }
    }
    private void MostrarProductos()
    {
        Console.WriteLine($"\n--- PEDIDO DE LA MESA {idMesa}, Seleccion de Producto---");
        var registros = db.LeerDatosCon("carta", $"id_categoria = {idCategoria}");

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
        int idProducto = Convert.ToInt32(registroSeleccionado["id"]);
        vista.espera();
        new ControladorOpcionCinco(vista, db, idMesa, idCategoria, idProducto).Empezar();
    }


}