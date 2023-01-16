using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Jardines2022.Datos.Repositorios
{
    public class ProveedorRepositorio: IProveedorRepositorio
    {
        private readonly Jardines2022DbContext context;
        public ProveedorRepositorio()
        {
            context = new Jardines2022DbContext();
        }

        public void Borrar(Proveedor proveedor)
        {
            try
            {
                context.Entry(proveedor).State = EntityState.Deleted;
                context.SaveChanges();
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
                if (proveedor.ProveedorId==0)
                {
                    return context.Proveedores.Any(p => p.NombreProveedor == proveedor.NombreProveedor);
                }
                return context.Proveedores.Any(p => p.NombreProveedor == proveedor.NombreProveedor 
                                                && p.CiudadId==proveedor.CiudadId
                                                && p.PaisId==proveedor.PaisId
                                                && p.ProveedorId != proveedor.ProveedorId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Proveedor> GetLista()
        {
            try
            {
                return context.Proveedores
                    .Include(p => p.ciudad)
                    .Include(p => p.pais)
                    .ToList();
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
                return context.Proveedores.SingleOrDefault(p => p.ProveedorId == id);
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
                if (proveedor.pais!=null)
                {
                    context.Paises.Attach(proveedor.pais);
                }
                if (proveedor.ciudad!=null)
                {
                    context.Ciudades.Attach(proveedor.ciudad);
                }
                if (proveedor.ProveedorId==0)
                {
                    context.Proveedores.Add(proveedor);
                }
                else
                {
                    var proveedorEnDb = context.Proveedores.SingleOrDefault(p => p.ProveedorId == proveedor.ProveedorId);
                    if (proveedorEnDb==null)
                    {
                        throw new Exception("El Proveedor es inexistente");
                    }
                    proveedorEnDb.ProveedorId = proveedor.ProveedorId;
                    proveedorEnDb.NombreProveedor = proveedor.NombreProveedor;
                    proveedorEnDb.Direccion = proveedor.Direccion;
                    proveedorEnDb.CodigoPostal = proveedor.CodigoPostal;
                    proveedorEnDb.CiudadId = proveedor.CiudadId;
                    proveedorEnDb.PaisId = proveedor.PaisId;
                    context.Entry(proveedorEnDb).State = EntityState.Modified;
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
