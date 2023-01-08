using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface IPaisesServicio
    {
        List<Pais> GetLista();
        Pais GetPaisPorId(int id);
        void Guardar(Pais pais);
        void Borrar(Pais pais);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
    }
}
