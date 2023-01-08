using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public Ciudad ciudad { get; set; }
        public int CiudadId { get; set; }
        public Pais pais { get; set; }
        public int PaisId { get; set; }
    }
}
