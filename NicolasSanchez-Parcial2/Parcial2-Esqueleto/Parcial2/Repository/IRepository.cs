using System;
using System.Collections.Generic;
using Parcial2.Models;

namespace Parcial2.Repository
{
    public interface IRepository<T> where T : IEntidad
    {
        List<T> LeerTodos();
        T BuscarPorId(int id);
        void Agregar(T item);
        void Actualizar(T item);
    }
}
