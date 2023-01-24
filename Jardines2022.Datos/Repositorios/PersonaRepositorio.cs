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
    public class PersonaRepositorio : IPersonaRepositorio
    {
        public Jardines2022DbContext context;
        public PersonaRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public void Borrar(Persona persona)
        {
            try
            {
                context.Entry(persona).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EstaRelacionado(Persona persona)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Persona persona)
        {
            try
            {
                if (persona.PersonaId==0)
                {
                    return context.Personas.Any(p => p.DNI == persona.DNI);
                }
                return context.Personas.Any(p => p.DNI == persona.DNI
                        && p.PersonaId != persona.PersonaId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Persona> GetLista()
        {
            try
            {
                return context.Personas
                    .Include(p => p.Pais)
                    .Include(p => p.Ciudad)
                    .Include(p => p.Usuario)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Persona GetPorID(int id)
        {
            try
            {
                return context.Personas.SingleOrDefault(p => p.PersonaId == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Guardar(Persona persona)
        {
            try
            {
                if (persona.Pais!=null)
                {
                    context.Paises.Attach(persona.Pais);
                }
                if (persona.Ciudad!=null)
                {
                    context.Ciudades.Attach(persona.Ciudad);
                }
                if (persona.Usuario!=null)
                {
                    context.Usuarios.Attach(persona.Usuario);
                }
                if (persona.PersonaId==0)
                {
                    context.Personas.Add(persona);
                }
                else
                {
                    var personaEnDB = context.Personas.SingleOrDefault(p => p.PersonaId == persona.PersonaId);
                    if (personaEnDB==null)
                    {
                        throw new Exception("La persona no existe");
                    }
                    personaEnDB.PersonaId = persona.PersonaId;
                    personaEnDB.Codigo = persona.Codigo;
                    personaEnDB.Nombre = persona.Nombre;
                    personaEnDB.Apellido = persona.Apellido;
                    personaEnDB.Direccion = persona.Direccion;
                    personaEnDB.CodigoPostal = persona.CodigoPostal;
                    personaEnDB.PaisId = persona.PaisId;
                    personaEnDB.CiudadId = persona.CiudadId;
                    personaEnDB.DNI = persona.DNI;
                    personaEnDB.UsuarioId = persona.UsuarioId;
                    context.Entry(personaEnDB).State = EntityState.Modified;
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
