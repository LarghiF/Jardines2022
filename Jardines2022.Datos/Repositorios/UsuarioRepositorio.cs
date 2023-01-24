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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Jardines2022DbContext context;
        public UsuarioRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public bool ExisteCorreo(string correo)
        {
            try
            {
                return context.Usuarios.Any(u => u.Correo == correo);
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
                return context.Usuarios.SingleOrDefault(u => u.UsuarioId == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario GetUsuarioCorreoYClave(string correo, string clave)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {
            try
            {
                return context.Usuarios.SingleOrDefault(u => u.Correo == correo);
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
                if (usuario.Rol!=null)
                {
                    context.Roles.Attach(usuario.Rol);
                }
                if (usuario.UsuarioId==0)
                {
                    context.Usuarios.Add(usuario);
                }
                else
                {
                    var usuarioEnDb = context.Usuarios.SingleOrDefault(u => u.UsuarioId == usuario.UsuarioId);
                    usuarioEnDb.Correo = usuario.Correo;
                    usuarioEnDb.Clave = usuario.Clave;
                    usuarioEnDb.Restablecer = usuario.Restablecer;
                    usuarioEnDb.RolId = usuario.RolId;
                    context.Entry(usuarioEnDb).State = EntityState.Modified;
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
