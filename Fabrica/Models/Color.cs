class Color
{
    public int Id { get; set; }
    // Inicializadas a string.Empty para evitar CS8618
    public string Nombre { get; set; } = string.Empty;
    public string CodigoPintura { get; set; } = string.Empty;
    public string Acabado { get; set; } = string.Empty;
}
