class ModeloHonda
{
    public int Id { get; set; }                           // NOT NULL
    public string Nombre { get; set; } = string.Empty;    // NOT NULL
    public string? CodigoModelo { get; set; }             // NULL
    public string? Segmento { get; set; }                 // NULL

    // 1. Constructor Vacío
    public ModeloHonda() { }

    // 2. Constructor Mínimo (Campos NOT NULL)
    public ModeloHonda(string nombre){
        Id = 0;
        Nombre = nombre;
    }

    // 3. Constructor Completo
    public ModeloHonda(int id, string nombre, string codigoModelo, string segmento){
        Id = id;
        Nombre = nombre;
        CodigoModelo = codigoModelo;
        Segmento = segmento;
    }
}