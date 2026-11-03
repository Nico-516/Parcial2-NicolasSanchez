namespace Parcial2.Models
{
    // Una línea de la orden: "2 x Pastillas de freno (par)".
    // Guarda la DESCRIPCIÓN y el PRECIO del momento: si mañana cambia el catálogo,
    // el presupuesto que ya se le pasó al cliente no cambia.
    public class ItemOrden
    {
        public string Descripcion { get; set; } = "";
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => PrecioUnitario * Cantidad;

        public override string ToString()
        {
            return $"{Cantidad} x {Descripcion}  —  {Subtotal:C0}";
        }
    }
}
