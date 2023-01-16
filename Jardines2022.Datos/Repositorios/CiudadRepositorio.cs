using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios
{
    public class CiudadRepositorio : ICiudadRepositorio
    {
        public Jardines2022DbContext context;
        public CiudadRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public List<CiudadListDto> GetLista()
        {
            try
            {
                return context.Ciudades
                .Include(c => c.Pais)
                .Select(c => new CiudadListDto()
                {
                    CiudadId = c.CiudadId,
                    NombreCiudad = c.NombreCiudad,
                    Pais = c.Pais.NombrePais
                }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Borrar(Ciudad ciudad)
        {
            try
            {
                context.Entry(ciudad).State = EntityState.Deleted;
                context.SaveChanges();
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
                if (ciudad.CiudadId==0)
                {
                    return context.Ciudades.Any(c => c.NombreCiudad == ciudad.NombreCiudad);
                }
                return context.Ciudades.Any(c => c.NombreCiudad == ciudad.NombreCiudad
                                            && c.CiudadId != ciudad.CiudadId);
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
                return context.Ciudades.SingleOrDefault(c => c.CiudadId == id);
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
                if (ciudad.CiudadId==0)
                {
                    context.Ciudades.Add(ciudad);
                }
                else
                {
                    context.Entry(ciudad).State = EntityState.Modified;
                }
                context.SaveChanges();
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
                return context.Ciudades
                    .OrderBy(c => c.NombreCiudad)
                    .Where(c => c.PaisId == id)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
