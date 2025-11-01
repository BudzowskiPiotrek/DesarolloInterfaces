class PaqueteExtras
{
    public int Id { get; set; }                           // NOT NULL (PK)
    public string Nombre { get; set; } = string.Empty;    // NOT NULL
    public string? Descripcion { get; set; }              // NULL
}