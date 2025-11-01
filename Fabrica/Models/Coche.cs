class Coche
{
    public string VIN { get; set; } = string.Empty;      // NOT NULL
    public int ModeloId { get; set; }                    // NOT NULL
    public int ColorId { get; set; }                     // NOT NULL
    public string? MotorSerie { get; set; }              // NULL
    public int PaqueteId { get; set; }                   // NOT NULL
    public DateTime? FechaFabricacion { get; set; }      // NULL
    public string? Observaciones { get; set; }           // NULL

    // solo para leer (Propiedades de navegación o JOINs)
    public string? ModeloNombre { get; set; }
    public string? ColorNombre { get; set; }
    public string? PaqueteNombre { get; set; }

    // 1. Constructor Vacío
    public Coche() { }

    // 2. Constructor Mínimo (Campos NOT NULL)
    public Coche(string vin, int modeloId, int colorId, int paqueteId)
    {
        VIN = vin;
        ModeloId = modeloId;
        ColorId = colorId;
        PaqueteId = paqueteId;
    }

    // 3. Constructor Completo
    public Coche(
        string vin, string? modeloNombre, string? colorNombre, string? paqueteNombre, string? motorSerie, DateTime? fechaFabricacion, string? observaciones)
    {
        VIN = vin;
        ModeloNombre = modeloNombre;
        ColorNombre = colorNombre;
        PaqueteNombre = paqueteNombre;
        MotorSerie = motorSerie;
        FechaFabricacion = fechaFabricacion;
        Observaciones = observaciones;
    }
}