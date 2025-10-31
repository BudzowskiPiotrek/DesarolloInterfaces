
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
        vin: "CristobalMobail",            // VIN único (string)
        modeloId: 1,                       // FK a ModeloHonda (int)
        colorId: 5,                        // FK a Color (int)
        motorSerie: "MTR-123456",          // FK a Motor (string)
        fechaFabricacion: DateTime.Now.Date // Fecha (DateTime)
    );
        
            db.InsertarCoche(nuevoCoche);
        
    }
}