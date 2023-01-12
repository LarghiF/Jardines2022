﻿using Jardines2022.Datos.Repositorios.IRepositorios;
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
        public ProductoRepositorio()
        {
            context = new Jardines2022DbContext();
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
                            && p.CategoriaId == producto.CategoriaId
                            && p.ProveedorId == producto.ProveedorId
                            && p.ProductoId != producto.ProductoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //try
            //{
            //    if (producto.ProductoId==0)
            //    {
            //        return context.Productos.Any(p => p.NombreProducto == producto.NombreProducto);
            //    }
            //    return context.Productos.Any(p => p.NombreProducto == producto.NombreProducto
            //                                    && p.ProductoId != producto.ProductoId);
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
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
                    .Include(p => p.Categoria)
                    .Include(p => p.Proveedor)
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
                if (producto.Proveedor!=null)
                {
                    context.Proveedores.Attach(producto.Proveedor);
                }
                if (producto.Categoria!=null)
                {
                    context.Categorias.Attach(producto.Categoria);
                }
                if (producto.ProductoId==0)
                {
                    context.Productos.Add(producto);
                }
                else
                {
                    var productoEnDb = context.Productos.SingleOrDefault(p => p.ProductoId == producto.ProductoId);
                    if (productoEnDb==null)
                    {
                        throw new Exception("No se ha encontrado el producto.");
                    }
                    productoEnDb.ProductoId = producto.ProductoId;
                    productoEnDb.NombreProducto= producto.NombreProducto;
                    productoEnDb.NombreLatin= producto.NombreLatin;
                    productoEnDb.ProveedorId= producto.ProveedorId;
                    productoEnDb.CategoriaId= producto.CategoriaId;
                    productoEnDb.PrecioUnitario= producto.PrecioUnitario;
                    productoEnDb.UnidadesEnStock= producto.UnidadesEnStock;
                    productoEnDb.NivelDeReposicion= producto.NivelDeReposicion;
                    productoEnDb.UnidadesEnPedido= producto.UnidadesEnPedido;
                    productoEnDb.Suspendido= producto.Suspendido;
                    context.Entry(productoEnDb).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            //try
            //{
            //    if (producto.ProductoId==0)
            //    {
            //        context.Productos.Add(producto);
            //    }
            //    else
            //    {
            //        context.Entry(producto).State = EntityState.Modified;
            //    }
            //    context.SaveChanges();
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
        }
    }
}
