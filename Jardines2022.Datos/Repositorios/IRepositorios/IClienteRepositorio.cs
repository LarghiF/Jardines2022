using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface IClienteRepositorio
    {
        List<Cliente> GetLista();
        void Guardar(Cliente cliente);
        bool ExisteCliente(Cliente cliente);
        bool ExisteCorreo(string correo);
        Cliente GetProID(int id);
        Cliente GetClientePorCorreo(string correo);
        Cliente GetClientePorCorreoYClave(string correo,string clave);
    }
}
