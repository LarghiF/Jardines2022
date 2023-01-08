using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface ICiudadRepositorio
    {
        List<CiudadListDto> GetLista();
        Ciudad GetCiudadPorId(int id);
        void Guardar(Ciudad ciudad);
        void Borrar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        bool EstaRelacionado(Ciudad ciudad);
    }
}
