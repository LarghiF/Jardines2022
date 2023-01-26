using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio repositorio;
        public UsuarioServicio(UsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool ExisteCorreo(string correo)
        {
            try
            {
                return repositorio.ExisteCorreo(correo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ExisteUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario GetPorID(int id)
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

        public Usuario GetUsuarioCorreoYClave(string correo, string clave)
        {
            try
            {
                return repositorio.GetUsuarioCorreoYClave(correo, clave);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {
            try
            {
                return repositorio.GetUsuarioPorCorreo(correo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Guardar(Usuario usuario)
        {
            try
            {
                repositorio.Guardar(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
