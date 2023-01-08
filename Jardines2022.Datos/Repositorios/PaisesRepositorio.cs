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
    public class PaisesRepositorio : IPaisesRepositorio
    {
        private Jardines2022DbContext context;
        public PaisesRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public void Borrar(Pais pais)
        {
            try
            {
                context.Entry(pais).State = EntityState.Deleted;
                context.SaveChanges();
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
                if (pais.PaisId == 0)
                {
                    return context.Paises.Any(m => m.NombrePais == pais.NombrePais);
                }

                return context.Paises.Any(m => m.NombrePais == pais.NombrePais
                                                   && m.PaisId != pais.PaisId);
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
                return context.Paises.ToList();
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
                return context.Paises.SingleOrDefault(c => c.PaisId == id);
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
                if (pais.PaisId == 0)
                {
                    context.Paises.Add(pais);
                }
                else
                {
                    context.Entry(pais).State = EntityState.Modified;
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
