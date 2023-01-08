using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios
{
    public class PaisesServicio : IPaisesServicio
    {
        private readonly IPaisesRepositorio repositorio;
        private readonly Jardines2022DbContext context;
        public PaisesServicio()
        {
            context = new Jardines2022DbContext();
            repositorio = new PaisesRepositorio(context);
        }
        public void Borrar(Pais pais)
        {
            try
            {
                repositorio.Borrar(pais);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Pais pais)
        {
            try
            {
                return repositorio.Existe(pais);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Pais> GetLista()
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

        public Pais GetPaisPorId(int id)
        {
            try
            {
                return repositorio.GetPaisPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Guardar(Pais pais)
        {
            try
            {
                repositorio.Guardar(pais);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
