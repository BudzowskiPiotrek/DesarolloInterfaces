public class Motor
{
    public int numeroBastidor { get; set; }
    public string tipoMotor { get; set; }
    public string cilindrada { get; set; }
    public bool montado { get; set; }

    public Motor(int numeroBastidor, string tipoMotor, string cilindrada)
    {
        this.numeroBastidor = numeroBastidor;
        this.tipoMotor = tipoMotor;
        this.cilindrada = cilindrada;
        this.montado = false;
    }
}