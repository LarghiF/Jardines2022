using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface ICategoriaServicio
    {
        List<Categoria> GetLista();
        Categoria GetCategoriaPorId(int id);
        void Guardar(Categoria categoria);
        void Borrar(Categoria categoria);
        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
    }
}
