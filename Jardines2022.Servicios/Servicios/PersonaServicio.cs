using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;

namespace Jardines2022.Servicios.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IPersonaRepositorio repositorio;
        private readonly Jardines2022DbContext context;
        public PersonaServicio(PersonaRepositorio repositorio,Jardines2022DbContext context)
        {
            this.context = context;
            this.repositorio = repositorio;
        }
        public void Borrar(Persona persona)
        {
            try
            {
                repositorio.Borrar(persona);
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
                return repositorio.Existe(persona);
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
                return repositorio.GetLista();
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
                return repositorio.GetPorID(id);
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
                repositorio.Guardar(persona);
            }
            catch (Exception e)
            {
                throw e; 
            }
        }
    }
}
