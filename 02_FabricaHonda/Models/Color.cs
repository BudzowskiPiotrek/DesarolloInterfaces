class Color
{
    public int Id { get; set; }                               // NOT NULL
    public string Nombre { get; set; } = string.Empty;        // NOT NULL
    public string CodigoPintura { get; set; } = string.Empty; // NOT NULL
    public string Acabado { get; set; } = string.Empty;       // ENUM NOT NULL
}
