class MotorTipo
{
    public int Id { get; set; }                              // NOT NULL (PK)
    public string Codigo { get; set; } = string.Empty;       // NOT NULL
    public string? Descripcion { get; set; }                 // NULL
    public int? CilindradaCC { get; set; }                   // NULL
    public string Alimentacion { get; set; } = string.Empty; // ENUM NOT NULL
}