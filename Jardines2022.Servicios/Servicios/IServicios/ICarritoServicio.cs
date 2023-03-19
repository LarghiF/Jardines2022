using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface ICarritoServicio
    {
        void AgregarAlCarrito(int usuarioId, int productoId, int cantidad);
        int Cantidad(int usuarioId);
        void Quitar(int usuarioId, int productoId);
        List<Carrito> ListaCarrito(int usuarioId);
        Carrito GetCarrito(int usuarioId, int productoId);
        void QuitarTodo(int usuarioId);
        void VaciarCarritoCompraFinalizada(int usuarioId);
    }
}
