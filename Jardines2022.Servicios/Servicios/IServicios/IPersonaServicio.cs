using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface IPersonaServicio
    {
        List<Persona> GetLista();
        Persona GetPorID(int id);
        Persona GetPorUID(int id);
        void Guardar(Persona persona);
        void Borrar(Persona persona);
        bool Existe(Persona persona);
        bool EstaRelacionado(Persona persona);
    }
}
