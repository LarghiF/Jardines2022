using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface IProveedorServicio
    {
        List<Proveedor> GetLista();
        Proveedor GetProveedorPorId(int id);
        void Guardar(Proveedor proveedor);
        void Borrar(Proveedor proveedor);
        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
    }
}
