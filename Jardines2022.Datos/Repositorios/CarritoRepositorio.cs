using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Jardines2022.Datos.Repositorios
{
    public class CarritoRepositorio : ICarritoRepositorio
    {
        private readonly Jardines2022DbContext context;
        public CarritoRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public void AgregarAlCarrito(int usuarioId, int productoId, int cantidad)
        {
            try
            {
                var productosSeleccionados = context.Carritos.SingleOrDefault(c => c.UsuarioId == usuarioId && c.ProductoId == productoId);
                if (productosSeleccionados==null)
                {
                    Carrito carrito = new Carrito()
                    {
                        ProductoId = productoId,
                        UsuarioId = usuarioId,
                        Cantidad = cantidad
                    };
                    context.Carritos.Add(carrito);
                }
                else
                {
                    productosSeleccionados.Cantidad += cantidad;
                    context.Entry(productosSeleccionados).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Cantidad(int usuarioId)
        {
            try
            {
                return context.Carritos.Count(u => u.UsuarioId == usuarioId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Carrito GetCarrito(int usuarioId, int productoId)
        {
            try
            {
                return context.Carritos.SingleOrDefault(c => c.UsuarioId == usuarioId && c.ProductoId == productoId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Carrito> ListaCarrito(int usuarioId)
        {
            try
            {
                return context.Carritos
                    .Include(c => c.Producto)
                    .Where(c => c.UsuarioId == usuarioId).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Quitar(int usuarioId, int productoId)
        {
            try
            {
                var carritoDb = context.Carritos.SingleOrDefault(c => c.UsuarioId == usuarioId && c.ProductoId == productoId);
                context.Entry(carritoDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void QuitarTodo(int usuarioId)
        {
            try
            {
                var lista = ListaCarrito(usuarioId);
                foreach (var carrito in lista)
                {
                    Quitar(usuarioId, carrito.ProductoId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
