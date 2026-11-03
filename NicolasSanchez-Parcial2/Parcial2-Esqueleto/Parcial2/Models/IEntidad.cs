using System;

namespace Parcial2.Models
{
    // Contrato mínimo para poder guardar algo en el repositorio: tener un Id.
    public interface IEntidad
    {
        int Id { get; set; }
    }
}
