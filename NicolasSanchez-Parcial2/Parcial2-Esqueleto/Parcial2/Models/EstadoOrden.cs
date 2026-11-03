namespace Parcial2.Models
{
    // Recorrido normal: Ingresada -> EnReparacion -> Terminada -> Retirada.
    // Cancelada es un estado final al que solo se llega desde Ingresada.
    public enum EstadoOrden
    {
        Ingresada,
        EnReparacion,
        Terminada,
        Retirada,
        Cancelada
    }
}
