
using System.ComponentModel.DataAnnotations;

class AdministrarCoches
{
    private VistaFabrica vista;
    private DbConsultas db;

    public AdministrarCoches(VistaFabrica vista, DbConsultas db)
    {
        this.vista = vista;
        this.db = db;
    }

    public void Empezar()
{
    Coche nuevoCoche = new Coche(
        vin: "CRISTOBAL-MOBILE",
        modeloId: 1,
        colorId: 5,
        paqueteId: 2
    );

    db.InsertarCoche(nuevoCoche);
}
}