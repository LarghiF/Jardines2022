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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private Jardines2022DbContext context;
        public CategoriaRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public void Borrar(Categoria categoria)
        {
            try
            {
                context.Entry(categoria).State = EntityState.Deleted;
                context.SaveChanges();
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
                if (categoria.CategoriaId == 0)
                {
                    return context.Categorias.Any(m => m.Descripcion == categoria.Descripcion);
                }

                return context.Categorias.Any(m => m.Descripcion == categoria.Descripcion
                                                   //&& m.NombreCategoria==categoria.NombreCategoria
                                                   && m.CategoriaId != categoria.CategoriaId);
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
                return context.Categorias.ToList();
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
                return context.Categorias.SingleOrDefault(c => c.CategoriaId == id);
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
                if (categoria.CategoriaId == 0)
                {
                    context.Categorias.Add(categoria);
                }
                else
                {
                    context.Entry(categoria).State = EntityState.Modified;
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
