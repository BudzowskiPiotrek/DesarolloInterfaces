class Motor
{
    public string NumSerie { get; set; } = string.Empty;  // NOT NULL (PK)
    public int MotorTipoId { get; set; }                  // NOT NULL
    public DateTime? FechaFabricacion { get; set; }       // NULL
    public decimal? PotenciaKW { get; set; }              // NULL
    public decimal? EmisionesWLTP { get; set; }           // NULL
}