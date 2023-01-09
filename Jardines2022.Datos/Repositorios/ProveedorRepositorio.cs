using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios
{
    public class ProveedorRepositorio: IProveedorRepositorio
    {
        private readonly Jardines2022DbContext context;
        public ProveedorRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }

        public void Borrar(Proveedor proveedor)
        {
            try
            {
                context.Entry(proveedor).State = EntityState.Deleted;
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
                return context.Proveedores.Any(p => p.NombreProveedor == proveedor.NombreProveedor &&
                                                p.ProveedorId != proveedor.ProveedorId);
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
                return context.Proveedores
                    //.Include(p=>p.ciudad)
                    //.Include(p=>p.pais)
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
                if (proveedor.ProveedorId==0)
                {
                    context.Proveedores.Add(proveedor);
                }
                else
                {
                    context.Entry(proveedor).State = EntityState.Modified;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
