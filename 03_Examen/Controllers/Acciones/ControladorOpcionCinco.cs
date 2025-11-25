using System.Collections.Generic;
public class ControladorOpcionCinco
{
    private Vista_Examen vista;
    private DB_Consultas db;
    private bool ejecutado = true;
    private int idMesa;
    private int idProducto;
    private int idCategoria;

    public ControladorOpcionCinco(Vista_Examen vista, DB_Consultas db, int idMesa, int idCategoria, int idProducto)
    {
        this.idMesa = idMesa;
        this.idCategoria = idCategoria;
        this.idProducto = idProducto;
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
    {
        while (ejecutado)
        {
            MostrarPresentaiones();
        }
    }


    private void MostrarPresentaiones()
    {
        Console.WriteLine(vista.mensajesControl[28]);
        var registros = db.LeerDatos("presentaciones");

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
        int idPresentacion = Convert.ToInt32(registroSeleccionado["id"]);
        vista.espera();
        try
        {
            MetodoInsertar(idPresentacion);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar la presentación: {ex.Message}");
            vista.mostrarError(1);
        }

    }



    private void MetodoInsertar(int id)
    {

        var nuevoPedidos = new Pedidos { id_mesa = this.idMesa, id_producto_carta = this.idProducto, id_presentacion = id };


        var nuevoRegistro = DB_Consultas.ConvertirObjetoADiccionario(nuevoPedidos);

        try
        {
            db.Insertar("pedidos", nuevoRegistro);
            vista.mostrarConfirmacion(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            vista.mostrarError(0);
        }
        new ControladorOpcionCuatro(vista, db, idMesa, idCategoria).Empezar();
    }
}
