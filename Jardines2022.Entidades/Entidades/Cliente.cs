using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        public Pais Pais { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
