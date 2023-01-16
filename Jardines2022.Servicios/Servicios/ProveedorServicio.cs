using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;

namespace Jardines2022.Servicios.Servicios
{
    public class ProveedorServicio: IProveedorServicio
    {
        private readonly IProveedorRepositorio repositorio;
        private readonly Jardines2022DbContext context;
        private readonly IUnitOfWork unitOfWork;
        public ProveedorServicio(ProveedorRepositorio repositorio, Jardines2022DbContext context, UnitOfWork unitOfWork)
        {
            this.repositorio = repositorio;
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public void Borrar(Proveedor proveedor)
        {
            try
            {
                repositorio.Borrar(proveedor);
                //unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                return repositorio.Existe(proveedor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Proveedor GetProveedorPorId(int id)
        {
            try
            {
                return repositorio.GetProveedorPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Proveedor> GetLista()
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

        public void Guardar(Proveedor proveedor)
        {
            try
            {
                repositorio.Guardar(proveedor);
                //unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
