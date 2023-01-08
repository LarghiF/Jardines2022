using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface IPaisesRepositorio
    {
        List<Pais> GetLista();
        Pais GetPaisPorId(int id);
        void Guardar(Pais pais);
        void Borrar(Pais pais);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
    }
}
