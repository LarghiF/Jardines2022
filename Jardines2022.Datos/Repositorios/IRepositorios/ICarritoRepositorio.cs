using Jardines2022.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface ICarritoRepositorio
    {
        void AgregarAlCarrito(int usuarioId, int productoId, int cantidad);
        //void AgregarAlCarrito(int clienteId, int productoId);
        int Cantidad(int usuarioId);
        void Quitar(int usuarioId, int productoId);
        List<Carrito> ListaCarrito(int usuarioId);
        Carrito GetCarrito(int usuarioId, int productoId);
        void QuitarTodo(int usuarioId);
    }
}
