namespace Parcial2.Models
{
    // Un trabajo o repuesto del catálogo del taller. El catálogo se lee de Datos/servicios.json.
    public class Servicio : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Categoria { get; set; } = "";
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Precio:C0})";
        }
    }
}
