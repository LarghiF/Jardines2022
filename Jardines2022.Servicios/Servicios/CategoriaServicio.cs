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
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ICategoriaRepositorio repositorio;
        private readonly Jardines2022DbContext context;
        public CategoriaServicio()
        {
            context = new Jardines2022DbContext();
            repositorio = new CategoriaRepositorio(context);
        }
        public void Borrar(Categoria categoria)
        {
            try
            {
                repositorio.Borrar(categoria);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                return repositorio.Existe(categoria);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Categoria GetCategoriaPorId(int id)
        {
            try
            {
               return repositorio.GetCategoriaPorId(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Categoria> GetLista()
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

        public void Guardar(Categoria categoria)
        {
            try
            {
                repositorio.Guardar(categoria);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
