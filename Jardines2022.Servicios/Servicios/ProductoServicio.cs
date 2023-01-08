using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;

namespace Jardines2022.Servicios.Servicios
{
    public class ProductoServicio: IProductoServicio
    {
        private readonly Jardines2022DbContext context;
        private readonly IProductoRepositorio repositorio;
        private readonly IUnitOfWork unitOfWork;
        public ProductoServicio(Jardines2022DbContext context,ProductoRepositorio repositorio,UnitOfWork unitOfWork)
        {
            this.context = context;
            this.repositorio = repositorio;
            this.unitOfWork = unitOfWork;
        }

        public void Borrar(Producto producto)
        {
            try
            {
                repositorio.Borrar(producto);
                unitOfWork.Save();
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
                return repositorio.Existe(producto);
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
                return repositorio.GetLista();
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
                return repositorio.GetProductoPorId(id);
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
                repositorio.Guardar(producto);
                unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
