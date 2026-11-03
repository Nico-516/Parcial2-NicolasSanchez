namespace Parcial2.Comprobantes
{
    // PATRÓN FACTORY METHOD — Creador concreto: solo sobrescribe el método fábrica.
    // TODO 8 · Factory Method: usá este archivo y FormatoTxt.cs de modelo para crear el presupuesto HTML.
    public class GeneradorComprobanteTxt : GeneradorComprobante
    {
        public override string Descripcion => "Comprobante de texto";
        public override string Extension => "txt";

        protected override IFormatoComprobante CrearFormato()
        {
            return new FormatoTxt();
        }
    }
}
