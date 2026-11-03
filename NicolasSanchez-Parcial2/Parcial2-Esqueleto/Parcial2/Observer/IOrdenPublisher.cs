namespace Parcial2.Observer
{
    // PATRÓN OBSERVER — interfaz Notificador (Publisher): alta y baja de suscriptores.
    public interface IOrdenPublisher
    {
        void Suscribir(IOrdenObserver observador);
        void Desuscribir(IOrdenObserver observador);
        void Notificar(EventoOrden evento);
    }
}
