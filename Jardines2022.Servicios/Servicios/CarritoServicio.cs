using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Jardines2022.Servicios.Servicios
{
    public class CarritoServicio : ICarritoServicio
    {
        private readonly ICarritoRepositorio repositorio;
        private readonly IProductoRepositorio productoRepositorio;
        private readonly IUnitOfWork unitOfWork;
        public CarritoServicio(CarritoRepositorio repositorio, ProductoRepositorio productoRepositorio, UnitOfWork unitOfWork)
        {
            this.repositorio = repositorio;
            this.productoRepositorio = productoRepositorio;
            this.unitOfWork = unitOfWork;
        }
        public void AgregarAlCarrito(int usuarioId, int productoId, int cantidad)
        {
            try
            {
                using (var transaction=new TransactionScope(TransactionScopeOption.Required))
                {
                    var productoDb = productoRepositorio.GetProductoPorId(productoId);
                    if (productoDb.UnidadesEnStock>=cantidad)
                    {
                        var carrito = repositorio.GetCarrito(usuarioId, productoId);
                        repositorio.AgregarAlCarrito(usuarioId, productoId,cantidad);
                        unitOfWork.Save();
                        productoRepositorio.ActualizarStock(productoId, cantidad,"-");
                        unitOfWork.Save();
                        transaction.Complete();
                    }
                    else
                    {
                        throw new Exception("Stock insuficiente!");
                    }
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
                return repositorio.Cantidad(usuarioId);
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
                return repositorio.GetCarrito(usuarioId, productoId);
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
                return repositorio.ListaCarrito(usuarioId);
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
                using (var transaction=new TransactionScope(TransactionScopeOption.Required))
                {
                    var carrto = repositorio.GetCarrito(usuarioId, productoId);
                    repositorio.Quitar(usuarioId, productoId);
                    unitOfWork.Save();
                    productoRepositorio.ActualizarStock(productoId, carrto.Cantidad, "+");
                    unitOfWork.Save();
                    transaction.Complete();
                }
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
                using (var transaction=new TransactionScope(TransactionScopeOption.Required))
                {
                    var carrito = repositorio.ListaCarrito(usuarioId);
                    foreach (var items in carrito)
                    {
                        repositorio.Quitar(usuarioId, items.ProductoId);
                        unitOfWork.Save();
                        productoRepositorio.ActualizarStock(items.ProductoId, items.Cantidad,"+");
                        unitOfWork.Save();
                    }
                    transaction.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void VaciarCarritoCompraFinalizada(int usuarioId)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                {
                    var carrito = repositorio.ListaCarrito(usuarioId);
                    foreach (var items in carrito)
                    {
                        repositorio.Quitar(usuarioId, items.ProductoId);
                        unitOfWork.Save();
                    }
                    transaction.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
