using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using System.Collections.Generic;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioListDto> GetLista();
        void Guardar(Usuario usuario);
        bool ExisteUsuario(Usuario usuario);
        bool ExisteCorreo(string correo);
        Usuario GetUsuarioPorCorreo(string correo);
        Usuario GetPorID(int id);
        Usuario GetUsuarioCorreoYClave(string correo, string clave);
    }
}
