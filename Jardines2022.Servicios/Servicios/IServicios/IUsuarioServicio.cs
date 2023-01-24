using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface IUsuarioServicio
    {
        void Guardar(Usuario usuario);
        bool ExisteUsuario(Usuario usuario);
        bool ExisteCorreo(string correo);
        Usuario GetUsuarioPorCorreo(string correo);
        Usuario GetPorID(int id);
        Usuario GetUsuarioCorreoYClave(string correo, string clave);
    }
}
