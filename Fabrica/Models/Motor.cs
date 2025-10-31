class Motor
{
    public string NumSerie { get; set; } = string.Empty; 
    public int MotorTipoId { get; set; } 
    public DateTime FechaFabricacion { get; set; }
    public decimal PotenciaKW { get; set; }
    public decimal? EmisionesWLTP { get; set; }
}