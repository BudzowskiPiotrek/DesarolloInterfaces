public class Coche
{
    public int idVehiculo { get; set; }
    public string modelo { get; set; }
    public Motor motor { get; set; }
    public string color { get; set; }
    public string tipoExtra { get; set; }


    public Coche(int idVehiculo, string modelo, Motor motor, string color, string tipoExtra)
    {
        this.idVehiculo = idVehiculo;
        this.modelo = modelo;
        this.motor = motor;
        this.color = color;
        this.tipoExtra = tipoExtra;
    }

}