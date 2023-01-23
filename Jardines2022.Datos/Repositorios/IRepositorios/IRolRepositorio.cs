using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface IRolRepositorio
    {
        List<Rol> GetLista();
        Rol GetPorId(int id);
        void Guardar(Rol rol);
        void Borrar(Rol rol);
        bool Existe(Rol rol);
    }
}
