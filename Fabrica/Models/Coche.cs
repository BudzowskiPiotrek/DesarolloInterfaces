class Coche
{
    public string VIN { get; set; } = string.Empty;
    public int ModeloId { get; set; }
    public int ColorId { get; set; }
    public string MotorSerie { get; set; } = string.Empty;
    public int? PaqueteId { get; set; }
    public DateTime FechaFabricacion { get; set; }
    public string? Observaciones { get; set; }

    // solo para leer (Propiedades de navegación o JOINs)
    public string? ModeloNombre { get; set; }
    public string? ColorNombre { get; set; }
    public string? PaqueteNombre { get; set; }

    // 1. Constructor Vacío
    public Coche() { }

    // 2. Constructor Mínimo (Campos NOT NULL)
    public Coche(string vin, int modeloId, int colorId, string motorSerie, DateTime fechaFabricacion)
    {
        VIN = vin;
        ModeloId = modeloId;
        ColorId = colorId;
        MotorSerie = motorSerie;
        FechaFabricacion = fechaFabricacion;
    }

    // 3. Constructor Completo
    public Coche(string vin, int modeloId, int colorId, string motorSerie, DateTime fechaFabricacion, int? paqueteId, string? observaciones)
    {
        VIN = vin;
        ModeloId = modeloId;
        ColorId = colorId;
        MotorSerie = motorSerie;
        FechaFabricacion = fechaFabricacion;
        PaqueteId = paqueteId;
        Observaciones = observaciones;
    }
}