public class SeguimientoAction
{
    private readonly VistaFabrica vista;
    private readonly RepositorioFabrica modelo;

    public SeguimientoAction(VistaFabrica vista, RepositorioFabrica modelo)
    {
        this.vista = vista;
        this.modelo = modelo;
    }

    public void empezar()
    {

        Console.WriteLine(vista.mensajesControl[2]);
        Console.WriteLine(vista.mensajesControl[8]);

        if (!int.TryParse(Console.ReadLine(), out int bastidorBuscado))
        {
            vista.mostrarError(3); 
            return;
        }

        Motor motorEncontrado = null;
        List<Motor> todosMotores = modelo.ObtenerMotoresDisponibles(); 
        foreach (Motor m in todosMotores)
        {
            if (m.numeroBastidor == bastidorBuscado)
            {
                motorEncontrado = m;
                break; 
            }
        }
        
        if (motorEncontrado == null)
        {
            vista.mostrarError(4);
        }
        else 
        {
    
            string infoMotor = $"{motorEncontrado.tipoMotor}";
            
            if (motorEncontrado.montado)
            {
                vista.mostrarConfirmacion(3);
            }
            else 
            {
                vista.mostrarConfirmacion(4);
            }
        }
    }
}