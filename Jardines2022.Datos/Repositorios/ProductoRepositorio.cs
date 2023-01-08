using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Jardines2022.Datos.Repositorios
{
    public class ProductoRepositorio: IProductoRepositorio
    {
        private readonly Jardines2022DbContext context;
        public ProductoRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }

        public void Borrar(Producto producto)
        {
            try
            {
                context.Entry(producto).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Producto producto)
        {
            try
            {
                if (producto.ProductoId==0)
                {
                    return context.Productos.Any(p => p.NombreProducto == producto.NombreProducto);
                }
                return context.Productos.Any(p => p.NombreProducto == producto.NombreProducto
                                                && p.ProductoId != producto.ProductoId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Producto GetProductoPorId(int id)
        {
            try
            {
                return context.Productos.SingleOrDefault(p => p.ProductoId == id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Producto> GetLista()
        {
            try
            {
                return context.Productos
                    .Include(p=>p.Categoria)
                    .Include(p=>p.Proveedor)
                    .ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Guardar(Producto producto)
        {
            try
            {
                if (producto.ProductoId==0)
                {
                    context.Productos.Add(producto);
                }
                else
                {
                    context.Entry(producto).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
