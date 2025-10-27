class Coche
{
    public int IdReal { get; set; }
    public int IdLogico { get; set; }
    public string VIN { get; set; }
    public int ModeloId { get; set; }
    public int? ColorId { get; set; }
    public int? PaqueteId { get; set; }
    public string? MotorSerie { get; set; }
    public string? Observaciones { get; set; }

    // solo para leer

    public string? ModeloNombre { get; set; }
    public string? ColorNombre { get; set; }
    public string? PaqueteNombre { get; set; }

    public Coche() { }
    public Coche(int idLogico, string vin, int modeloId)
    {
        IdLogico = idLogico;
        VIN = vin;
        ModeloId = modeloId;
    }
    public Coche(int idReal, int idLogico, string vin, int modeloId, int? colorId, int? paqueteId, string? motorSerie, string? observaciones)
    {
        IdReal = idReal;
        IdLogico = idLogico;
        VIN = vin;
        ModeloId = modeloId;
        ColorId = colorId;
        PaqueteId = paqueteId;
        MotorSerie = motorSerie;
        Observaciones = observaciones;
    }


}