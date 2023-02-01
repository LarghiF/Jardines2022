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
            try
            {
                if (usuario.UsuarioId==0)
                {
                    return context.Usuarios.Any(u => u.Correo == usuario.Correo);
                }
                return context.Usuarios.Any(u => u.Correo == usuario.Correo
                                            && u.Correo == usuario.Correo
                                            && u.UsuarioId == usuario.UsuarioId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<UsuarioListDto> GetLista()
        {
            try
            {
                return context.Usuarios
                    .Select(u => new UsuarioListDto()
                    {
                        UsuarioId = u.UsuarioId,
                        Correo = u.Correo,
                        RolId = (int)u.RolId
                    }).ToList();
            }
            catch (Exception e)
            {
                throw e; 
            }
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
            try
            {
                return context.Usuarios.SingleOrDefault(u => u.Correo == correo && u.Clave == clave);
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
                if (usuario.UsuarioId==0)
                {
                    usuario.PaisId = 0;
                    usuario.CiudadId = 0;
                    context.Usuarios.Add(usuario);
                }
                else
                {
                    var usuarioEnDb = context.Usuarios.SingleOrDefault(u => u.UsuarioId == usuario.UsuarioId);
                    usuarioEnDb.Correo = usuario.Correo;
                    usuarioEnDb.Clave = usuario.Clave;
                    usuarioEnDb.Restablecer = usuario.Restablecer;
                    usuarioEnDb.RolId = usuario.RolId;
                    usuarioEnDb.Nombre = usuario.Nombre;
                    usuarioEnDb.Apellido = usuario.Apellido;
                    usuarioEnDb.Direccion = usuario.Direccion;
                    usuarioEnDb.CodigoPostal = usuario.CodigoPostal;
                    usuarioEnDb.DNI = usuario.DNI;
                    usuarioEnDb.Valido = usuario.Valido;
                    usuarioEnDb.PaisId = usuario.PaisId;
                    usuarioEnDb.CiudadId = usuario.CiudadId;

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
