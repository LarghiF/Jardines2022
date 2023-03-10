using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios.IRepositorios
{
    public interface IPersonaRepositorio
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
