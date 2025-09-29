public class RepositorioFabrica
{
    private static List<Motor> motores = new List<Motor>();
    private static List<Coche> vehiculos = new List<Coche>();
    private static int siguenteVehiculoId = 1;

    public RepositorioFabrica()
    {
        if (!motores.Any())
        {
            motores.Add(new Motor(1234, "gasolina 1.5", "1.5"));
            motores.Add(new Motor(5678, "diesel 2.1", "2.1"));
        }
    }

    public List<Motor> ObtenerMotoresDisponibles()
    {
        return motores;
    }

    public List<Coche> ObtenerTodosVehiculos()
    {
        return vehiculos;
    }
    public void RegistrarMotor(Motor nuevoMotor)
    {
        motores.Add(nuevoMotor);
    }
    public void ConstruirVehiculo(string modelo, string color, string tipoExtra, int bastidorMotor)
    {
        Motor motorSeleccionado = null;

        foreach (Motor motor in motores)
        {
            if (motor.numeroBastidor == bastidorMotor && motor.montado == false)
            {
                motorSeleccionado = motor;
                break;
            }
        }

        Coche nuevoCoche = new Coche(siguenteVehiculoId, modelo, motorSeleccionado, color, tipoExtra);
        vehiculos.Add(nuevoCoche);
        siguenteVehiculoId++;
        motorSeleccionado.montado = true;
    }
}