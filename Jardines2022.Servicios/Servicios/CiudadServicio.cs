using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly ICiudadRepositorio repositorio;
        private readonly Jardines2022DbContext context;
        public CiudadServicio()
        {
            context = new Jardines2022DbContext();
            repositorio = new CiudadRepositorio(context);
        }
        public void Borrar(Ciudad ciudad)
        {
            try
            {
                repositorio.Borrar(ciudad);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return repositorio.Existe(ciudad);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Ciudad> GetCiudadesPorPais(int id)
        {
            try
            {
                return repositorio.GetCiudadesPorPais(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Ciudad GetCiudadPorId(int id)
        {
            try
            {
                return repositorio.GetCiudadPorId(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<CiudadListDto> GetLista()
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

        public void Guardar(Ciudad ciudad)
        {
            try
            {
                repositorio.Guardar(ciudad);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
