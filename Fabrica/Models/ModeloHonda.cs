class ModeloHonda
{
     public int Id { get; set; }                           // NOT NULL
    public string Nombre { get; set; } = string.Empty;    // NOT NULL
    public string? CodigoModelo { get; set; }             // NULL
    public string? Segmento { get; set; }                 // NULL
}